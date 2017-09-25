using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace S4L.Old.UI {
    public class Mana : Statistic {

        void Awake() {
            image = GameObject.Find("PlayerManaSlider").GetComponent<Image>();
        }
    }
}