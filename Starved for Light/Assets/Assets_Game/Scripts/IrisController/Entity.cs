using System;
using UnityEngine;

public class Entity : MonoBehaviour
{
	
	private State state;

	public Entity (){
		state = new GroundedState();
	}

	void Update () {
		state.Execute(gameObject);
	}

	public void SetState(State s){
		s.OnEnter(gameObject);
		state = s;
	}


}

