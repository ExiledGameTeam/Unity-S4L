using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mana : Statistic {

	void Awake(){
		image = GameObject.Find("PlayerManaSlider").GetComponent<Image>();
	}
}
