using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTarget : MonoBehaviour {

    [SerializeField] private GameObject m_Player;

    [SerializeField] private float m_XLead, m_YLead;

    private Vector3 m_Offset; //difference between character and camera follow point

    private Rigidbody2D rb;

	// Use this for initialization
	void Start () {

        //if the player GameObject has not been set manually
        if (!m_Player)
        {
            //set it to the game object of the parent
            m_Player = transform.parent.transform.gameObject;
        }
        //get the difference at level start
        m_Offset = transform.position - m_Player.transform.position;

        //get the rigidbody of the player
        rb = m_Player.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = m_Player.transform.position + m_Offset + new Vector3(rb.velocity.x * m_XLead, rb.velocity.y * m_YLead);
	}
}
