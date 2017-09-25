using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace S4L.Old.UI {
    public class Endurance : Statistic {

        void Awake() {
            image = GameObject.Find("PlayerEnduranceSlider").GetComponent<Image>();
        }
    }
}

