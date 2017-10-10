using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace S4L.Test {
    public class CameraTargetTester : MonoBehaviour {

        public Enums.PlayerButtonInput targetAButton = Enums.PlayerButtonInput.Jump;
        public Transform targetA;
        public Enums.PlayerButtonInput targetBButton = Enums.PlayerButtonInput.Gallop;
        public Transform targetB;

        void OnEnable() {
            EventManager.OnPlayerInput += CheckInputs;
        }

        void OnDisable() {
            EventManager.OnPlayerInput -= CheckInputs;
        }

        void CheckInputs(
            List<Tuple<Enums.PlayerAxisInput, float>> par1,
            List<Tuple<Enums.PlayerButtonInput, Enums.ButtonEvent>> par2
        ) {
            foreach (var item in par2) {
                if (item.value1 == targetAButton) {
                    if (item.value2 == Enums.ButtonEvent.Up) {
                        ChangeTarget(targetA);
                    }
                } else if (item.value1 == targetBButton) {
                    if (item.value2 == Enums.ButtonEvent.Up) {
                        ChangeTarget(targetB);
                    }
                }
            }
        }

        void ChangeTarget(Transform newTarget) {
            EventManager.Trigger(EventManager.OnCameraTargetChanged, newTarget);
        }
    }
}

