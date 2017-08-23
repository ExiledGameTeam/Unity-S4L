using UnityEngine;
using System.Collections;

public class NewBehaviourScript : MonoBehaviour {

	public GameObject caster;

	// Use this for initialization
	void Start () {
		if(caster){
			for (int i=0; i<500; i++){
				GameObject nn = Instantiate(caster);
				nn.name = "nn" + i.ToString();
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
