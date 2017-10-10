using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace S4L.Test {
    public class DontDestroyOnLoad : MonoBehaviour {
        void Awake() {
            DontDestroyOnLoad(this);
        }
    }
}

