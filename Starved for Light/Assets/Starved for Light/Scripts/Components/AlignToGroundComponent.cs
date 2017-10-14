using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace S4L {
    public class AlignToGroundComponent : MonoBehaviour {

        private Transform t;
        private float lastAngle;
        private float normalAngle;
        public float raycastDistance = 2f;

        private void Awake() {
            t = transform;
            lastAngle = Vector2.Angle(Vector2.up, Physics2D.gravity.normalized);
        }

        private void Update() {
            normalAngle = Vector2.SignedAngle(Vector2.down, GroundNormal(t.position, Vector2.down, raycastDistance));
            AlignToNormal(t, lastAngle, normalAngle);
            lastAngle = (lastAngle + normalAngle) / 2f;
        }

        private void AlignToNormal(Transform target, float lastAngle, float normalAngle) {
            float angle = (lastAngle + normalAngle) / 2f;

            target.rotation = Quaternion.Euler(0, 0, angle);
        }

        public float GetCurrentAngle() {
            return normalAngle;
        }

        public static Vector2 GroundNormal(
            Vector2 startPosition, Vector2 raycastAngle, float raycastDistance
        ) {
            //Raycast for ground objects
            RaycastHit2D[] hits = 
                Physics2D.RaycastAll(
                startPosition, 
                raycastAngle, 
                raycastDistance,
                Consts.LayerMasks.Ground
                );

            //Return first ground object
            foreach (var hit in hits) {
                Debug.DrawLine(startPosition, hit.point, Color.yellow);
                Debug.DrawLine(
                    hit.point,
                    hit.point + hit.normal,
                    Color.green);
            }
            if (hits.Length > 0) {
                return hits[0].normal;
            }

            Debug.DrawLine(startPosition, 
                startPosition + raycastAngle * raycastDistance, 
                Color.red
                );
            return Physics2D.gravity.normalized;
        }
    }
}
