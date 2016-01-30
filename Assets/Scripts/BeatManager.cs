using UnityEngine;
using System.Collections;

public class BeatManager : MonoBehaviour {
	public static BeatManager Instance;
	public AudioClip beatClip;

	float startTime;
	float beatSeconds = 1;

	AudioSource audio;

	public delegate void BeatAction();
	public static event BeatAction OnBeat;

	public bool isPlaying;

	void Awake(){
		Instance = this;
		isPlaying = false;
		audio = this.GetComponent<AudioSource> ();
		OnBeat += PlayBeatClip;
	}

	// Use this for initialization
	void Start () {
		BeginBeat();
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log (SecondsUntilBeat ());
	}

	void BeginBeat(){
		startTime = Time.time;
		isPlaying = true;
		StartCoroutine ("BeatSound");
	}

	//returns the millis of the upcoming beat
	public float NextBeatTime(){
		float nextBeat = Time.time + SecondsUntilBeat();
		return nextBeat;
	}

	public float SecondsUntilBeat(){
		float timeToBeat = beatSeconds - (Time.time - startTime)%beatSeconds;
		return timeToBeat;
	}

	void PlayBeatClip(){
		audio.PlayOneShot(beatClip);
		Debug.Log("BeatSound");
	}


	private IEnumerator BeatSound(){
		while(isPlaying){
			OnBeat();
		yield return new WaitForSeconds(SecondsUntilBeat());
		
		}
	}
}
