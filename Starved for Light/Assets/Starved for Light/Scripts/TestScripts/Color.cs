using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colour : MonoBehaviour {

    private SVGImporter.SVGRenderer SVG;

	// Use this for initialization
	void Start () {
        SVG = GetComponent<SVGImporter.SVGRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.R))
        {
            SVG.color = Color.red;
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            SVG.color = Color.green;
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            SVG.color = Color.blue;
        }

    }
}
