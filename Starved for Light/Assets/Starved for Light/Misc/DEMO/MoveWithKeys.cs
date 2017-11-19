using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TeamUtility.IO;

public class MoveWithKeys : MonoBehaviour {

  public float mSpeed;

	void Start () {
    }
	

	void Update () {
        transform.Translate(mSpeed * InputManager.GetAxis("Horizontal") * Time.deltaTime, mSpeed * InputManager.GetAxis("Vertical") * Time.deltaTime, 0f);
	}
}
