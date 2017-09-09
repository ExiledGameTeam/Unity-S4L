using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : Statistic {

	public float waitForRegenerationTime = 1f;
	public float regenerationTime = 1000f;

	private float lastTimeHit = 0;

	void Awake(){
		image = GameObject.Find("PlayerHealthSlider").GetComponent<Image>();
	}

	void Update () {
		lastTimeHit += Time.deltaTime;
		if(!isMax() && lastTimeHit > waitForRegenerationTime){
			actualValue += 1.0f/regenerationTime * maxValue;
			Normalize();
		}
		if(image != null){
			image.fillAmount = actualValue / maxValue;	
		}
	}

	public void DealDamage(float damage){
		lastTimeHit = 0f;
		DecreaseActualValueBy(damage);
		Normalize();
	}

	public void OnMouseDown(){
		DealDamage(90);
	}
}
