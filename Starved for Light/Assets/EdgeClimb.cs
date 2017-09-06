using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EdgeClimb : MonoBehaviour {
    public Rigidbody2D RB2D;
    public Collider2D LowEdge;
    public LunaControl_v2 IrisControler;


    // Use this for initialization
    void Start () {
        IrisControler = RB2D.GetComponent<LunaControl_v2>();
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
            RB2D.AddForce(new Vector2(0, IrisControler.LowEdgeJumpForce));
        }
    }
}
