using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class StateMachine : MonoBehaviour {

    public enum IrisStates
    {
        Idle,
        Move,
        Sneak,
        Crawl,
        Galop,
        FirstJump,
        SecondJump,
        OnEdge,
        Hover
    }
    private IrisStates _state;
    public IrisStates state
    	{
		get
		{
			return _state;
		}
        set
		{
            ExitState(_state);
            _state = value;
            EnterState(_state);
		}
	}

	void Awake () {
        state = IrisStates.Idle;
	}

	void Update () {
        //////////////
        //For Debug///
        //////////////

        if (state == IrisStates.Idle)
            Debug.Log("Iris is Idle");
        if (state == IrisStates.Move)
            Debug.Log("Iris is Moving");
        if (state == IrisStates.Sneak)
            Debug.Log("Iris is Sneaking");
        if (state == IrisStates.Crawl)
            Debug.Log("Iris is Crawling");
        if (state == IrisStates.Galop)
            Debug.Log("Iris is Galoping");
        if (state == IrisStates.FirstJump)
            Debug.Log("Iris Just Jumped");
        if (state == IrisStates.SecondJump)
            Debug.Log("Iris Just Double Jumped");
        if (state == IrisStates.OnEdge)
            Debug.Log("Iris is hanging on Edge");
        if (state == IrisStates.Hover)
            Debug.Log("Iris is Hovering");

        //////////////
        //////////////
        //////////////
    }
}
