using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kursor : MonoBehaviour {

    public Texture2D cursorTexture;
    private Vector2 hotSpot = Vector2.zero;

	// Use this for initialization
	void Start () {
        Cursor.SetCursor(cursorTexture, hotSpot, CursorMode.ForceSoftware);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
