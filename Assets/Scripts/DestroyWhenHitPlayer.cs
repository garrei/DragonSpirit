﻿using UnityEngine;
using System.Collections;

public class DestroyWhenHitPlayer : MonoBehaviour {

	public GameObject explosion;
	Transform myTransform;

	// Use this for initialization
	void Start () {
		myTransform = transform;
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter2D (Collider2D other){
		if(other.CompareTag("Player") && gameObject.CompareTag("Airborne") && PlayerHealth.myOpacity > 0.9f){
		Instantiate (explosion,myTransform.position, Quaternion.identity);
		Destroy (gameObject);
		}
	}
}
