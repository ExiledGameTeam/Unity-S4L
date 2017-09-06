using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TeamUtility.IO;

public class GroundedState : State {

	public void Execute(GameObject entity){
		if(Input.GetKeyDown(KeyCode.Mouse0)){
			Debug.Log("NowStanding");
		}
		if(InputManager.GetButton("Jump")){
			Debug.Log("ChangeToJump");
			Entity e = entity.GetComponent<Entity>();
			e.SetState(new JumpingState());
		}
	}

	public void OnEnter(GameObject entity){

	}

	public void OnExit(GameObject entity){

	}
}
