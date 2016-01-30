using UnityEngine;
using System.Collections;

public class ControlManager : MonoBehaviour 
{
	public delegate void KeyAction();
	public static event KeyAction OnKeyUpArrow;
	public static event KeyAction OnKeyDownArrow;
	public static event KeyAction OnKeyLeftArrow;
	public static event KeyAction OnKeyRightArrow;

	void Awake () 
	{
		OnKeyUpArrow 	+= ActionHighFive;
		OnKeyDownArrow 	+= ActionBroFist;
		OnKeyLeftArrow 	+= ActionSlapRight;
		OnKeyRightArrow += ActionSlapLeft;
	}

	void Update () 
	{
		if (Input.GetKeyDown (KeyCode.UpArrow)) {
			OnKeyUpArrow ();
		} else if (Input.GetKeyDown (KeyCode.DownArrow)) {
			OnKeyDownArrow ();
		} else if (Input.GetKeyDown (KeyCode.LeftArrow)) {
			OnKeyLeftArrow ();
		} else if (Input.GetKeyDown (KeyCode.RightArrow)) {
			OnKeyRightArrow ();
		}
	}

	void ActionBroFist ()
	{
		StartCoroutine ("BroFist");
	}

	IEnumerator BroFist()
	{
		Debug.Log ("Action: BroFist");
		yield return true;
	}

	void ActionHighFive()
	{
		StartCoroutine ("HighFive");
	}

	IEnumerator HighFive()
	{
		Debug.Log ("Action: HighFive");
		yield return true;
	}

	void ActionSlapLeft()
	{
		StartCoroutine ("SlapLeft");
	}

	IEnumerator SlapLeft()
	{
		Debug.Log ("Action: SlapLeft");
		yield return true;
	}

	void ActionSlapRight()
	{
		StartCoroutine ("SlapRight");
	}

	IEnumerator SlapRight()
	{
		Debug.Log ("Action: SlapRight");
		yield return true;
	}
}
