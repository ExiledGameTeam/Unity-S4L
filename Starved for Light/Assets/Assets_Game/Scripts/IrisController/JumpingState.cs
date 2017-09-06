using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TeamUtility.IO;

public class JumpingState : State {

	public float jumpForce = 46f;
	public float _maxJumpForce = 2f;
	public float tJumpSpeed = 0f;

	private bool isJumping;
	Rigidbody2D RB2D;

	public void Execute(GameObject entity){
		if(Input.GetKeyDown(KeyCode.Mouse0)){
			Debug.Log("NowJumping");
		}
		if(Input.GetKeyDown(KeyCode.Mouse1)){
			Debug.Log("ChangeStateToStanding");
			Entity e = entity.GetComponent<Entity>();
			e.SetState(new GroundedState());
		}
//		if(!Input.GetKey(KeyCode.Space)){
//			isJumping = false;
//		}
//		if(isJumping){
//			Jump();
//		}
	}

	public void OnEnter(GameObject entity){
		isJumping = true;
		RB2D = entity.GetComponent<Rigidbody2D>();
		entity.GetComponent<Rigidbody2D>().velocity += new Vector2(0,7);
	}

	public void OnExit(GameObject entity){

	}

	private void Jump(){
		//Vector2 force = new Vector2(0, jumpForce * (Mathf.Lerp(_maxJumpForce, 0f, tJumpSpeed)));
		//Vector2 force = new Vector2(0, 100);
		//RB2D.AddForce(force);
		//RB2D.velocity.y = 20;
	}
}
