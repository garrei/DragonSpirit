using UnityEngine;
using System.Collections;

public class BulletFiringGraiaBehaviour : MonoBehaviour {

	Transform playerTransform;
	Transform myTransform;
	public GameObject myProjectile;
	int speedVertical = 7;
	int speedHorizontal = 2;
	bool isTurning = false;
	float rangeVertical = 2;
	float rangeHorizontal = 1.5f;
	Vector3 moveDirectionVertical = Vector3.down;
	Vector3 moveDirectionHorizontal = new Vector2 (0,0);
	SpriteRenderer mySprite;
	Animator anim;

	// Use this for initialization
	void Start () {
		//Finding the player this way should make it more compatable between scenes
		playerTransform = GameObject.Find ("PlayerGraphic").transform;

		myTransform = transform;

		//We need to grab the sprite so we can flip it later
		mySprite = GetComponent <SpriteRenderer> ();

		anim = GetComponent <Animator> ();
	}

	// Update is called once per frame
	void Update () {
		
		if (myTransform.position.y < playerTransform.position.y + rangeVertical && myTransform.position.x < playerTransform.position.x + rangeHorizontal && myTransform.position.x > playerTransform.position.x - rangeHorizontal && myTransform.position.y > playerTransform.position.y && mySprite.flipY == false) {
			moveDirectionVertical = Vector3.up;
			mySprite.flipY = true;
			Instantiate (myProjectile, myTransform.position, Quaternion.identity);
		}

		//This moves the transform left and right and flips the sprite accordingly
		if (myTransform.position.x > playerTransform.position.x + rangeHorizontal && myTransform.position.y > playerTransform.position.y) {
			moveDirectionHorizontal = Vector2.left;
			isTurning = true;
			mySprite.flipX = false;
		}
		if (myTransform.position.x < playerTransform.position.x - rangeHorizontal && myTransform.position.y > playerTransform.position.y) {
			moveDirectionHorizontal = Vector2.right;
			isTurning = true;
			mySprite.flipX = true;
		}
		myTransform.Translate (moveDirectionVertical* Time.deltaTime * speedVertical);
		myTransform.Translate (moveDirectionHorizontal * Time.deltaTime * speedHorizontal);
		anim.SetBool ("isTurning",isTurning);   
	}
}