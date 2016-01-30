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
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log (SecondsUntilBeat ());
	}

	public void BeginBeat(){
		if (isPlaying)
			return;
		startTime = Time.time;
		isPlaying = true;
		StartCoroutine ("BeatSound");
	}

	public void EndBeat(){
		isPlaying = false;
	}

	//returns the millis of the upcoming beat
	public float NextBeatTime(){
		float nextBeat = Time.time + SecondsUntilBeat();
		return nextBeat;
	}

	public float SecondsUntilBeat(){
		float timeToBeat = beatSeconds - SecondsSinceLastBeat();
		return timeToBeat;
	}

	public float SecondsSinceLastBeat(){
		float timeFromBeat = (Time.time - startTime)%beatSeconds;
		return timeFromBeat;
	}

	void PlayBeatClip(){
		audio.PlayOneShot(beatClip);
	}


	private IEnumerator BeatSound(){
		while(isPlaying){
			OnBeat();
			Debug.Log("BeatSound");
		yield return new WaitForSeconds(SecondsUntilBeat());
		
		}
	}
}
