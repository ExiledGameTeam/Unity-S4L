using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace S4L.Old.UI {
    public class Loading : MonoBehaviour {

        AsyncOperation async;
        public Animator anim;

        void Start() {
            anim = GetComponent<Animator>();
            anim.SetBool("Run", true);

            async = SceneManager.LoadSceneAsync(2);

            async.allowSceneActivation = false;
        }

        void Update() {
            Debug.Log(async.progress);

            if (async.progress > 0.8f) {
                print("done");
            }
        }
    }
}
