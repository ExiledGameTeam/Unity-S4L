using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace S4L.Old {
    public class colour : MonoBehaviour {
        private SVGImporter.SVGRenderer SVG;

        void Start() {
            SVG = GetComponent<SVGImporter.SVGRenderer>();
        }

        void Update() {
            if (Input.GetKeyDown(KeyCode.R)) {
                SVG.color = Color.red;
            }
            if (Input.GetKeyDown(KeyCode.G)) {
                SVG.color = Color.green;
            }
            if (Input.GetKeyDown(KeyCode.B)) {
                SVG.color = Color.blue;
            }
        }
    }
}
