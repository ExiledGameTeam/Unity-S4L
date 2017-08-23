using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Variables : MonoBehaviour {

    int myInt = 5;

	// Use this for initialization
	void Start () {
        myInt = MultiplyByTwo(myInt);
        Debug.Log(myInt);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    int MultiplyByTwo(int number)
    {
        int ret;

        ret = number * 2;

        return ret;
    }
}
