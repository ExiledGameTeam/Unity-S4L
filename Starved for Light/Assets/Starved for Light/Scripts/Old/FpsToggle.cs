using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace S4L.Old {
    public class FpsToggle : MonoBehaviour {

        public GameObject fps;

        void Update() {
            if (Input.GetKeyDown(KeyCode.F3)) {
                if (fps.activeSelf) {
                    fps.SetActive(false);
                } else {
                    fps.SetActive(true);
                }
            }
        }
    }
}
