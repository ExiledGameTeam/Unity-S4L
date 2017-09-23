using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Loading : MonoBehaviour
{

    AsyncOperation async;
    public Animator anim;

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        anim.SetBool("Run", true);
        
        async = SceneManager.LoadSceneAsync(2);

        async.allowSceneActivation = false;
    }
	
	// Update is called once per frame
	void Update () {
        Debug.Log(async.progress);
        
        if (async.progress > 0.8f)
        {
            print("done");
        }
	}
}
