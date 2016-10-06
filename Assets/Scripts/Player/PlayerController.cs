﻿using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	Transform myTransform;
	Rigidbody2D rb;
	float currentSpeed, speedNormal = 5, speedDiag;
	public bool canMoveLeft = true, canMoveRight = true;
	float movement = 0;
	public static int playerScore = 0;

	//Camera
	public Camera cam;
	float camHeight, camWidth;

	// Use this for initialization
	void Start () {
		myTransform = transform;
		rb = GetComponent<Rigidbody2D>();
		speedDiag = speedNormal * 2/3;
	}

	// Update is called once per frame
	void Update () {
		
		//When both axes are called at the same time the player wil move slightly faster
		//This can be fixed by changing the speed when this occurs
		if(Input.GetAxisRaw ("Vertical") == 1 && Input.GetAxisRaw ("Horizontal") == 1){
			currentSpeed = speedDiag;
		}
		else if(Input.GetAxisRaw ("Vertical") == 1 && Input.GetAxisRaw ("Horizontal") == -1){
			currentSpeed = speedDiag;
		}
		else if(Input.GetAxisRaw ("Vertical") == -1 && Input.GetAxisRaw ("Horizontal") == 1){
			currentSpeed = speedDiag;
		}
		else if(Input.GetAxisRaw ("Vertical") == 1 && Input.GetAxisRaw ("Horizontal") == 1){
			currentSpeed = speedDiag;
		}
		else if(Input.GetAxisRaw ("Vertical") == -1 && Input.GetAxisRaw ("Horizontal") == -1){
			currentSpeed = speedDiag;
		}
		else {
			currentSpeed = speedNormal;
		}

		//Setting camera constraint variables
		camHeight = 2* cam.orthographicSize;
		camWidth = camHeight * cam.aspect;

		//Movement constraints
		//X axis camera constraints
		if(myTransform.position.x > camWidth/2 - camWidth/40){
			myTransform.position = new Vector2 (camWidth/2 - camWidth/40,myTransform.position.y);
			canMoveRight = false;
		}
		if(myTransform.position.x < -camWidth/2 + camWidth/40){
			myTransform.position = new Vector2 (-camWidth/2 + camWidth/40,myTransform.position.y);
			canMoveLeft = false;
		}

		//Y axis camera constraints
		if(myTransform.position.y > camHeight-camHeight/13){
			myTransform.position = new Vector2 (myTransform.position.x,camHeight-camHeight/13);
		}
		if(myTransform.position.y < camHeight/30){
			myTransform.position = new Vector2 (myTransform.position.x,camHeight/30);
		}

		//Fixing the jittering of the terrain
		if (canMoveLeft == false && Input.GetAxisRaw("Horizontal") < 0) {
			movement = 0;
		} 
		else if (canMoveRight == false && Input.GetAxisRaw("Horizontal") > 0) {
			movement = 0;
		} 
		else {
			movement = Input.GetAxisRaw ("Horizontal");
		}
		if(Input.GetAxisRaw("Horizontal") > 0){
			canMoveLeft = true;
		}
		if(Input.GetAxisRaw("Horizontal") < 0){
			canMoveRight = true;
		}

		//Movement
		rb.velocity = new Vector2 (movement*currentSpeed, Input.GetAxisRaw("Vertical")*currentSpeed);
	}
}
