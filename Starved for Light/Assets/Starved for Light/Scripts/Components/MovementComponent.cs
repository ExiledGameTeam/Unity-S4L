using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace S4L {
    [RequireComponent(typeof(Rigidbody2D))]
    public class MovementComponent : MonoBehaviour {

        private Rigidbody2D rb;
        private Transform t;

        public bool asd;
        public float maxWalkSpeed = 1f;

        private void Awake() {
            rb = GetComponent<Rigidbody2D>();
            t = GetComponent<Transform>();
        }

        public void MoveHorizontal(float direction) {
            if (asd) {
                rb.MovePosition((Vector2)t.position +
                    Time.deltaTime * new Vector2(
                    direction * maxWalkSpeed, 0f) +
                    rb.velocity +
                    rb.gravityScale * Physics2D.gravity * Time.deltaTime
                );
            } else {
                rb.AddForce(new Vector2(1000f * Time.deltaTime * direction, 0f));
                rb.velocity = Vector2.ClampMagnitude(rb.velocity, maxWalkSpeed);
            }
        }
    }
}
