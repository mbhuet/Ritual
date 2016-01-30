using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

// This is a sample state manager that uses
public class MainStateManager : MonoBehaviour 
{
	#region VARIABLES
	// INSTANCE
	public static MainStateManager instance;

	// STATES
	public SimpleStateMachine stateMachine;
	SimpleState menuState, playState, endState;
	#endregion

	void Awake () 
	{
		instance = this;
	}

	void Start () 
	{
		//DEFINE STATES
		menuState = new SimpleState(MenuEnter, MenuUpdate, MenuExit, "[MENU]");
		playState = new SimpleState(PlayEnter, PlayUpdate, PlayExit, "[PLAY]");
		endState = new SimpleState(EndEnter, EndUpdate, EndExit, "[END]");

		// this is how you switch states!
		stateMachine.SwitchStates(menuState);
	}

	void Update() 
	{
		Execute();
	}

	// This is called every frame. 
	public void Execute () 
	{
		stateMachine.Execute();
	}

	#region MENU
	void MenuEnter() 
	{
	
	}

	void MenuUpdate() 
	{
		stateMachine.SwitchStates(playState);
	}

	void MenuExit()
	{
		
	}
	#endregion

	#region CALIBRATE
	Timer calibrateTimer;

	void PlayEnter() 
	{
		
	}

	void PlayUpdate() 
	{
		
	}	

	void PlayExit()
	{
		
	}
	#endregion

	#region END
	void EndEnter() 
	{
		
	}

	void EndUpdate() 
	{
		
	}

	void EndExit() 
	{

	}
	#endregion
}
