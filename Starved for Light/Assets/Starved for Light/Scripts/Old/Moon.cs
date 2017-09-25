using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace S4L.Old {
    public class Moon : MonoBehaviour {
        Transform bar;
        public int MoonOffset;

        void Start() {
            bar = GameObject.Find("Main Camera").transform;
        }

        void Update() {
            transform.position = new Vector3(bar.position.x + MoonOffset, transform.position.y, transform.position.z);
        }
    }
}
