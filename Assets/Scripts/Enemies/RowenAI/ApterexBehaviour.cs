using UnityEngine;
using System.Collections;

public class ApterexBehaviour : MonoBehaviour {

	Transform playerTransform;
	Transform myTransform;
	public Transform rotatePoint;
	bool isOrbiting = false;
	int speedVertical = 7;
	int speedHorizontal = 2;
	float rotateSpeed = 0.75f;
	Vector3 moveDirectionHorizontal = new Vector2 (0,0);

	// Use this for initialization
	void Start () {
		//Finding the player this way should make it more compatable between scenes
		playerTransform = GameObject.Find ("PlayerGraphic").transform;

		myTransform = transform;
	}

	// Update is called once per frame
	void Update () {
		//This moves the transform left and right and flips the sprite accordingly
		if ( myTransform.position.x > playerTransform.position.x) {
			moveDirectionHorizontal = Vector2.left;
		}
		if (myTransform.position.x < playerTransform.position.x) {
			moveDirectionHorizontal = Vector2.right;
		}
		if(myTransform.position.y < playerTransform.position.y){
			isOrbiting = true;
		}
		if(isOrbiting == false){
		myTransform.Translate (Vector2.down * Time.deltaTime * speedVertical);
		}
		if(isOrbiting == true){
			myTransform.position = new Vector2 (myTransform.position.x,playerTransform.position.y);
			rotatePoint.Rotate (Vector3.forward * rotateSpeed);
		}
		myTransform.Translate (moveDirectionHorizontal * Time.deltaTime * speedHorizontal);
	}
}