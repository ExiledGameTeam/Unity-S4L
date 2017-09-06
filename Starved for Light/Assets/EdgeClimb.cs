using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EdgeClimb : MonoBehaviour {
    public Rigidbody2D RB2D;
    public Collider2D LowEdge;
    public LunaControl_v2 IrisControler;
    public GameObject Iris;
    public GameObject IrisBody;


    // Use this for initialization
    void Start () {
        Iris = GameObject.Find("Luna_Character");
        IrisBody = GameObject.Find("Body collision");

        IrisControler = Iris.GetComponent<LunaControl_v2>();
        LowEdge = IrisBody.GetComponent<Collider2D>();
        RB2D = Iris.GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other == LowEdge)
        {
            RB2D.velocity = new Vector2(0,0);
            Debug.Log("entered");
            RB2D.AddForce(new Vector2(200f, IrisControler.LowEdgeJumpForce));
        }
    }
}
