﻿using UnityEngine;
using System.Collections;

public class Eggs : MonoBehaviour {

	public GameObject orb;
	public GameObject eggAnim;
	Transform myTransform;


	// Use this for initialization
	void Start () {
		myTransform = transform;
	}

	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter2D (Collider2D other){
		if(other.CompareTag("WeaponDown")){
			Instantiate (orb, myTransform.position, Quaternion.identity);
			Instantiate (eggAnim, myTransform.position, Quaternion.identity);
			Destroy (gameObject);
		}
	}
}
