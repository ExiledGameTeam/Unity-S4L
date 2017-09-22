using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FpsToggle : MonoBehaviour {

    public GameObject fps;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.F3)) {
            if (fps.activeSelf) {
                fps.SetActive(false);
                    }
            else
            {
                fps.SetActive(true);
            }

        }
	}
}

