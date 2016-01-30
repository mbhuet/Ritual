using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public enum Gesture{
	FISTBUMP,
	WIDEFIVE,
	SHORTFIVE,
	FOREARMSLIDE,
	ELBOWBUMP,
	SNAP,
	EXPLOSION


}

[RequireComponent(typeof(Animator))]
public class Arm : MonoBehaviour {
	public List<Gesture> sequence;
	int gestureIndex=-1;
	Animator animator;


	void Awake(){
		BeatManager.OnBeat += TriggerNextGesture;
		animator = this.GetComponent<Animator> ();
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void TriggerNextGesture(){
		gestureIndex++;
		if (gestureIndex >= sequence.Count) {
			StopAnimation();
			return;
		}
		switch (sequence [gestureIndex]) {
		case Gesture.FISTBUMP:
			animator.SetTrigger("FistBump");
			break;
		case Gesture.WIDEFIVE:
			animator.SetTrigger("WideFive");
			break;
		default:
			break;
		
		}

	}

	void StopAnimation(){
		animator.SetTrigger ("Stop");
	}
}
