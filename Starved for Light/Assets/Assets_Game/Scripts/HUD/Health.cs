using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

	public float health = 100f;
	public float maxHealth = 100f;
	public float waitTime = 5f;
	public float regenerationTime = 1000f;

	public float lastTimeHit;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		lastTimeHit += Time.deltaTime;
		if(lastTimeHit > waitTime){
			health += 1.0f/regenerationTime * maxHealth;
			NormalizeHealth();
		}
	}

	public void GetHit(float damage){
		lastTimeHit = 0f;
		health -= damage;
		NormalizeHealth();
	}

	private void NormalizeHealth(){
		if(health < 0){
			health = 0;
		} else if (health > maxHealth) {
			health = maxHealth;
		}
	}

	public void OnMouseDown(){
		GetHit(90);
	}
}
