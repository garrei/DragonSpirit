using UnityEngine;
using System.Collections;

public class PlesiosaurusBeheviour : MonoBehaviour {

	Transform myTransform;
	Transform playerTransform;
	Transform myBody;
	float speedHorizontal = 1;
	float speedVertical = 1;
	Vector2 moveDirectionHorizontal = Vector2.right;
	Vector2 moveDirectionVertical = Vector2.down;
	public GameObject myBullet;
	float fireRate = 0.6f;
	float nextFire = 0;

	// Use this for initialization
	void Start () {
		myTransform = transform;
		playerTransform = GameObject.Find ("PlayerGraphic").transform;
		myBody = GameObject.Find ("Body").transform;
	}
	
	// Update is called once per frame
	void Update () {

		if(myTransform.position.x >= playerTransform.position.x){
			moveDirectionHorizontal = Vector2.left;
		}

		if(myTransform.position.x <= playerTransform.position.x){
			moveDirectionHorizontal = Vector2.right;
		}
		/*
		if(myTransform.position.x < playerTransform.position.x + 0.2f && myTransform.position.x > playerTransform.position.x - 0.2f){

		}
		*/

		if(myTransform.position.y >= 1f && myTransform.position.y > myBody.position.y - 4){
			moveDirectionVertical = Vector2.down;
		}

		if(myTransform.position.y <= -0.5f){
			moveDirectionVertical = Vector2.up;
		}

		if(myTransform.position.y < myBody.position.y - 4){
			moveDirectionVertical = Vector2.up;
		}

		if(Time.time > nextFire){
			nextFire = Time.time + fireRate;
			Instantiate (myBullet, new Vector3(myTransform.position.x, myTransform.position.y - 0.5f, 0), Quaternion.identity);
		}

		myTransform.Translate (moveDirectionHorizontal * speedHorizontal * Time.deltaTime);
		myTransform.Translate (moveDirectionVertical * speedVertical * Time.deltaTime);
	}
}