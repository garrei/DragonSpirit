﻿using UnityEngine;
using System.Collections;

public class EnemyHealthButDoesntDestroyEverything : MonoBehaviour {

	public int health = 1;
	public int score = 0;
	public GameObject spawnOnDeath;
	Transform myTransform;
	GameObject myTerrain;

	// Update is called once per frame
	void Start (){
		myTransform = transform;
		myTerrain = GameObject.Find ("Terrain");
	}

	void Update () {

		if ((health < 1 && myTransform.parent == null) || (health < 1 && CompareTag("Credits"))){
			OnDeath ();
			Destroy (gameObject);
		} else
			if (health < 1 && myTransform.parent.parent != null){
				OnDeath ();
				if(gameObject.transform.parent.parent.gameObject != myTerrain){
				Destroy (gameObject);
				}
				if(gameObject.transform.parent.parent.gameObject == myTerrain){
					Destroy (gameObject);
				}
			} else
				if (health < 1 && myTransform.parent != null){
					OnDeath ();
					if(gameObject.transform.parent.gameObject != myTerrain){
					Destroy (gameObject);
					}
					if(gameObject.transform.parent.gameObject == myTerrain){
						Destroy (gameObject);
					}
				}
	}

	void OnDeath (){
		UIManager.runScore += score;
		Instantiate (spawnOnDeath, myTransform.position,Quaternion.identity);
	}

	//This checks whether the bullet should hit the enemy or not depending on it being airbourne or not
	void OnTriggerEnter2D (Collider2D other){
		if((other.CompareTag("WeaponForward") && gameObject.CompareTag("Airborne")) || (other.CompareTag("WeaponForward") && gameObject.CompareTag("Credits"))){
			Destroy (other.gameObject);
			health--;
		}
		if(other.CompareTag("WeaponDown") && gameObject.CompareTag("Grounded")){
			Destroy (other.gameObject);
			health--;
		}
	}
}
