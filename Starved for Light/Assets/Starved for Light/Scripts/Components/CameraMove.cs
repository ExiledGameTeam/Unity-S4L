using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace S4L {
    public class CameraMove : MonoBehaviour {
        public float dampTime = 0.15f;

        private Camera cam;
        private Transform currentTarget = null;
        private List<Transform> lastTargets = new List<Transform>();
        private Vector3 velocity = Vector3.zero;

        void Start() {
            cam = GetComponent<Camera>();
        }

        void OnEnable() {
            EventManager.OnCameraTargetChanged += ChangeCameraTarget;
        }

        void OnDisable() {
            EventManager.OnCameraTargetChanged -= ChangeCameraTarget;
        }

        void Update() {
            if (!currentTarget) {
                return;
            }
            MoveUpdate();
        }

        private void ChangeCameraTarget(Transform newTarget) {
            if (newTarget == currentTarget) {
                return;
            }
            if (newTarget) {
                if (lastTargets.Contains(newTarget)) {
                    lastTargets.Remove(newTarget);
                } 
                if (lastTargets.Contains(currentTarget)) {
                    lastTargets.Remove(currentTarget);
                    lastTargets.Add(currentTarget);
                }
                if (currentTarget) {
                    lastTargets.Add(currentTarget);
                }
                currentTarget = newTarget;
                return;
            }

            // null -> Return to last valid target
            while (lastTargets.Count > 0 &&
                lastTargets[lastTargets.Count - 1] == null
            ) {
                lastTargets.Remove(lastTargets[lastTargets.Count - 1]);
            }

            if (lastTargets.Count > 0) {
                currentTarget = lastTargets[lastTargets.Count - 1];
                return;
            }
            currentTarget = null;
        }

        private void MoveUpdate() {
            Vector3 delta = currentTarget.position - cam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0.5f));
            Vector3 destination = transform.position + delta;
            transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
        }
    }
}
