using UnityEngine;
using System.Collections;

public class GraiaBehaviour : MonoBehaviour {

	Transform playerTransform;
	Transform myTransform;
	int speedVertical = 7;
	int speedHorizontal = 2;
	float rangeHorizontal = 1.5f;
	Vector3 moveDirectionHorizontal = new Vector2 (0,0);
	SpriteRenderer mySprite;

	// Use this for initialization
	void Start () {
		//Finding the player this way should make it more compatable between scenes
		playerTransform = GameObject.Find ("PlayerGraphic").transform;

		myTransform = transform;

		//We need to grab the sprite so we can flip it later
		mySprite = GetComponent <SpriteRenderer> ();
	}

	// Update is called once per frame
	void Update () {

		//This moves the transform left and right and flips the sprite accordingly
		if (myTransform.position.x < playerTransform.position.x + rangeHorizontal && myTransform.position.y > playerTransform.position.y) {
			moveDirectionHorizontal = Vector2.left;
			mySprite.flipX = false;
		}
		if (myTransform.position.x < playerTransform.position.x - rangeHorizontal && myTransform.position.y > playerTransform.position.y) {
			moveDirectionHorizontal = Vector2.right;
			mySprite.flipX = true;
		}

		myTransform.Translate (Vector2.down* Time.deltaTime * speedVertical);
		myTransform.Translate (moveDirectionHorizontal * Time.deltaTime * speedHorizontal);
	}
}
