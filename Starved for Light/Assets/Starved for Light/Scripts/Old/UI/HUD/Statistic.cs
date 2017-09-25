using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace S4L.Old.UI {
    public abstract class Statistic : MonoBehaviour {

        public float actualValue = 100;
        public float maxValue = 100;

        public Image image;

        public void IncreaseMaxValueBy(float delta) {
            maxValue += delta;
        }

        public void IncreaseActualValueBy(float delta) {
            actualValue += delta;
        }

        public void DecreaseMaxValueBy(float delta) {
            maxValue -= delta;
        }

        public void DecreaseActualValueBy(float delta) {
            actualValue -= delta;
        }

        public void SetMaxValueTo(float newValue) {
            maxValue = newValue;
        }

        public void SetActualValueTo(float newValue) {
            maxValue = newValue;
        }

        public bool isMax() {
            return actualValue == maxValue;
        }

        protected void Normalize() {
            if (actualValue < 0) {
                actualValue = 0;
            } else if (actualValue > maxValue) {
                actualValue = maxValue;
            }
        }

        public void Update() {
            actualValue += 1.0f / 1000.0f * maxValue;
            Normalize();
            if (image != null) {
                image.fillAmount = actualValue / maxValue;
            }
        }

        public void OnMouseDown() {
            actualValue -= 50;
        }
    }
}