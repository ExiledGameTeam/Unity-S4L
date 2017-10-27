using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace S4L {
    public class AlignToGroundComponent : MonoBehaviour {

        private static bool debug = true;
        private float rayAngle;
        private float normalAngle;
        public float raycastDistance = 2f;

        //RECODE: These are used for coroutine, don't use these if you remove coroutine.
        public float angleGoal;
        public float angle;
        public Quaternion goal;
        //Some magic number from misiek's code
        public float magic = 32;

        private void Awake() {
            rayAngle = Vector2.Angle(Vector2.up, Physics2D.gravity.normalized);
        }

        public void Align(Transform t) {
            Vector2 rayStartPosition = (Vector2)t.position + new Vector2(0f, 1f);
            //normalAngle = Vector2.SignedAngle(Vector2.down, GroundNormal(rayStartPosition, Vector2.down, raycastDistance));

            Vector2 groundNormal = GroundNormal(rayStartPosition, Vector2.down, raycastDistance);
            groundNormal.y *= -1f;
            float currentAngle = t.eulerAngles.z;
            currentAngle -= currentAngle > 180 ? 360f : 0f;
            float newAngle = 180f + (Mathf.Atan2(groundNormal.x, groundNormal.y) * Mathf.Rad2Deg);

            newAngle += newAngle < 0 ? 360f : 0f;
            newAngle -= newAngle > 180f ? 360f : 0f;
            
            //t.rotation = Quaternion.Euler(new Vector3(0, 0, newAngle));

            //REDCODE: Running a new coroutine each frame is very costy
            StartCoroutine(ChangeSpeed(angle, newAngle, 2f));
            goal = Quaternion.Euler(0, 0, angle);

            t.rotation = Quaternion.Lerp(t.rotation, goal, magic * Time.deltaTime);
            if (debug) {
                //Debug.Log("Current Z: " + t.eulerAngles.z + " New Z: " + /*angleGoal + ", " + */newAngle);
            }
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
            if (debug) {
                foreach (var hit in hits) {
                    Debug.DrawLine(startPosition, hit.point, Color.yellow);
                    Debug.DrawLine(
                        hit.point,
                        hit.point + hit.normal,
                        Color.green);
                }
            }
            
            if (hits.Length > 0) {
                return hits[0].normal;
            }

            if (debug) {
                Debug.DrawLine(startPosition,
                startPosition + raycastAngle * raycastDistance,
                Color.red
                );
            }
            return -Physics2D.gravity.normalized;
        }

        //RECODE: Use something else instead of triggering a coroutine each frame.
        IEnumerator ChangeSpeed(float v_start, float v_end, float duration) {
            float elapsed = 0.0f;
            while (elapsed < duration) {
                angle = Mathf.Lerp(v_start, v_end, elapsed / duration);
                elapsed += magic * Time.deltaTime;
                yield return null;
            }
        }
    }
}
