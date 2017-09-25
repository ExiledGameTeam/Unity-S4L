using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace S4L.Old {
    public class EdgeClimb : MonoBehaviour {
        public Rigidbody2D RB2D;
        public Collider2D LowEdge;
        public Collider2D HighEdge;
        public LunaControl_v2 IrisControler;
        public GameObject Iris;
        public GameObject IrisBody;
        public GameObject IrisBodyHigh;
        public GameObject TargetObject;
        public Transform target;

        public float GrabSpeed = 0f;

        void Start() {
            Iris = GameObject.Find("Luna_Character");
            IrisBody = GameObject.Find("Edge_low Check");
            IrisBodyHigh = GameObject.Find("Edge_High Check");
            TargetObject = GameObject.Find("PointToGrab");

            IrisControler = Iris.GetComponent<LunaControl_v2>();
            LowEdge = IrisBody.GetComponent<Collider2D>();
            HighEdge = IrisBodyHigh.GetComponent<Collider2D>();
            RB2D = Iris.GetComponent<Rigidbody2D>();

            target = TargetObject.GetComponent<Transform>();
        }

        void OnTriggerEnter2D(Collider2D other) {
            if (other == LowEdge & IrisControler.facingRight) {
                RB2D.velocity = new Vector2(0, 0);
                RB2D.AddForce(new Vector2(200f, IrisControler.LowEdgeJumpForce));
            }
            if (other == LowEdge & !IrisControler.facingRight) {
                RB2D.velocity = new Vector2(0, 0);
                RB2D.AddForce(new Vector2(-200f, IrisControler.LowEdgeJumpForce));
            }

            if (other == HighEdge) {
                RB2D.gravityScale = 0f;
                //float step = GrabSpeed * Time.deltaTime;
                //TODO: Continue here
            }
        }
    }
}
