using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public float dampTime = 0.15f;
    private Vector3 velocity = Vector3.zero;
    public Transform target;
    private Camera camera1;
    void Start ()
    {
        camera1 = GetComponent<Camera>();
    }
	
	void Update ()
    {
        Vector3 point = camera1.WorldToViewportPoint(target.position);
        Vector3 delta = target.position - camera1.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0.5f));
        Vector3 destination = transform.position + delta;
        transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
	}
}
