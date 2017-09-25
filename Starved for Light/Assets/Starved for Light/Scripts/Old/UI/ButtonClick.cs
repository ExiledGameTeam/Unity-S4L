using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using TeamUtility.IO;

namespace S4L.Old.UI {
    public class ButtonClick : MonoBehaviour {

        bool StartPassed = true;
        //Time variable was never used
        //float time = 10f;
        public GameObject CameraF;
        //Display was never used
        //private TextMeshProUGUI display;
        Animator anim;
        Animator cameraFanim;
        public GameObject selected;

        void Start() {
            anim = GetComponent<Animator>();
            cameraFanim = CameraF.GetComponent<Animator>();
            //display = GetComponent<TextMeshProUGUI>();
            anim.SetBool("Pressed", false);
        }

        void Update() {
            if (Input.anyKeyDown && StartPassed) {
                Debug.Log("ToMainMenu");
                anim.SetBool("Pressed", true);
                anim.speed = 2.0f;
                cameraFanim.Play("WelcomeToStart", -1, 0f);
                StartPassed = false;
            }
        }
    }
}