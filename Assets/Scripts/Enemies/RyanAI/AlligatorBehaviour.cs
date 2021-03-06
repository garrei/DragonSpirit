﻿using UnityEngine;
using System.Collections;

public class AlligatorBehaviour : MonoBehaviour {

	Transform playerTransform;
	Transform myTransform;

	public GameObject myProjectile;
	float shootCooldown = 2;
	float speedVertical = 1.5f;
	Animator anim;
	Vector3 bulletPosition;
	Vector3 moveDirectionVertical = Vector3.down;
	SpriteRenderer mySprite;

	// Use this for initialization
	void Start () {
		//Finding the player this way should make it more compatable between scenes
		playerTransform = GameObject.Find ("PlayerGraphic").transform;

		myTransform = transform;
		anim = GetComponent <Animator> ();
		mySprite = GetComponent <SpriteRenderer> ();
		bulletPosition = new Vector3(transform.position.x, transform.position.y - 0.5f);

	}

	// Update is called once per frame
	void Update () {

		//if (myTransform.position.y < playerTransform.position.y + rangeVertical && myTransform.position.x < playerTransform.position.x + rangeHorizontal && myTransform.position.x > playerTransform.position.x - rangeHorizontal && myTransform.position.y > playerTransform.position.y) {

			//speedVertical = 0;
			//mySprite.flipY = false;
		//}

		if (myTransform.position.y < playerTransform.position.y - 1) 
		{
			speedVertical = 1.5f;
			mySprite.flipY = false;
		}
		//Shoot Right
		if (playerTransform.position.x - myTransform.position.x >= 0.5f && myTransform.position.y < playerTransform.position.y + 4) 
		{
			bulletPosition = new Vector3 (transform.position.x + 0.2f, transform.position.y - 0.3f);
			speedVertical = 0;
			anim.SetBool ("isToTheSide",true);
			mySprite.flipX = true;
		}
		//Shoot Left
		if (playerTransform.position.x  - myTransform.position.x <= -0.5f  && myTransform.position.y < playerTransform.position.y + 4)
		{
			bulletPosition = new Vector3(transform.position.x - 0.2f, transform.position.y - 0.3f);
			speedVertical = 0;
			anim.SetBool ("isToTheSide",true);
			mySprite.flipX = false;
		}

			if (playerTransform.position.x - myTransform.position.x >= -0.5f && playerTransform.position.x - myTransform.position.x <= 0.5f && myTransform.position.y < playerTransform.position.y + 4)
		{
			bulletPosition = new Vector3(transform.position.x, transform.position.y - 0.2f);
			speedVertical = 0;
			anim.SetBool ("isToTheSide",false);

		}

		if (shootCooldown <= Time.time)
		{
			Attack ();
			shootCooldown = Time.time + 2f;
		}



		myTransform.Translate (moveDirectionVertical * Time.deltaTime * speedVertical);
		bulletPosition = new Vector3(transform.position.x, transform.position.y - 0.5f);
	}

	void Attack ()
	{

			anim.SetTrigger ("isShoot");
			GameObject bullet = (GameObject)Instantiate (myProjectile);
			bullet.transform.position = bulletPosition;
			Vector2 direction = playerTransform.transform.position - bullet.transform.position;
			bullet.GetComponent<EnemyProjectileTowardsPlayer>().setDirection (direction);
			shootCooldown = Time.time + 2f;

	}
}
