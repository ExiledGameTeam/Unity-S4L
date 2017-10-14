using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace S4L {
    [RequireComponent(typeof(Rigidbody2D))]
    public class MovementComponent : MonoBehaviour {

        public bool useMovePosition;
        public float maxWalkSpeed = 1f;

        public void MoveHorizontal(Rigidbody2D rb, Transform t, float direction) {
            if (useMovePosition) {
                rb.MovePosition(t.position +
                    Quaternion.Euler(0, 0, t.rotation.z) * (Time.deltaTime * new Vector2(
                    direction * maxWalkSpeed, 0f)) +
                    (Vector3)rb.velocity +
                    rb.gravityScale * (Vector3)Physics2D.gravity * Time.deltaTime
                );
                
            } else {
                rb.AddForce(Quaternion.Euler(0, 0, t.rotation.z) * 
                    new Vector2(1000f * Time.deltaTime * direction, 0f));
                rb.velocity = Vector2.ClampMagnitude(rb.velocity, maxWalkSpeed);
                Debug.DrawLine(transform.position, t.position +
                    (Quaternion.Euler(0, 0, t.rotation.z) * new Vector3(
                    direction * maxWalkSpeed, 0f) +
                    (Vector3)rb.velocity +
                    rb.gravityScale * (Vector3)Physics2D.gravity) * 10f, Color.magenta);
            }
        }
    }
}
