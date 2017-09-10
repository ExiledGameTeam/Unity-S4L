using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EdgeClimb : MonoBehaviour {
    public Rigidbody2D RB2D;
    public Collider2D LowEdge;
    public Collider2D HighEdge;
    public LunaControl_v2 IrisControler;
    public GameObject Iris;
    public GameObject IrisBody;
    public GameObject IrisBodyHigh;
    public GameObject target;

    public bool grabbed = false;

    public float GrabSpeed = 0f;

    // Use this for initialization
    void Start () {
        Iris = GameObject.Find("Luna_Character");
        IrisBody = GameObject.Find("Edge_low Check");
        IrisBodyHigh = GameObject.Find("Edge_High Check");

        IrisControler = Iris.GetComponent<LunaControl_v2>();
        LowEdge = IrisBody.GetComponent<Collider2D>();
        HighEdge = IrisBodyHigh.GetComponent<Collider2D>();
        RB2D = Iris.GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other == LowEdge & IrisControler.facingRight)
        {
            RB2D.velocity = new Vector2(0,0);
            RB2D.AddForce(new Vector2(200f, IrisControler.LowEdgeJumpForce));
        }
        if (other == LowEdge & !IrisControler.facingRight)
        {
            RB2D.velocity = new Vector2(0, 0);
            RB2D.AddForce(new Vector2(-200f, IrisControler.LowEdgeJumpForce));
        }

        if (other == HighEdge)
        {
            grabbed = true;
            RB2D.gravityScale = 0f;
            RB2D.velocity = new Vector2(0, 0);
        }
    }
    void Update()
    {
        if (grabbed)
        {
            float step = GrabSpeed * Time.deltaTime;
            Debug.Log("grabbing");
            Iris.transform.position = Vector3.MoveTowards(Iris.transform.position, target.transform.position, step);
        }
    }

}
