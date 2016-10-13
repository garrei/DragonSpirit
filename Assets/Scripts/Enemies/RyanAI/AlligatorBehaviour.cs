using UnityEngine;
using System.Collections;

public class AlligatorBehaviour : MonoBehaviour {

	Transform playerTransform;
	Transform myTransform;
<<<<<<< HEAD
	public GameObject alligatorProjectile;
	int speedVertical = 2;
	int speedHorizontal = 0;
	float rangeVertical = 4;
	float rangeHorizontal = 10f;
=======
	int speedVertical = 7;
	int speedHorizontal = 2;
	float rangeVertical = 2;
	float rangeHorizontal = 1.5f;
>>>>>>> origin/master
	Vector3 moveDirectionVertical = Vector3.down;
	Vector3 moveDirectionHorizontal = Vector3.right;
	SpriteRenderer mySprite;

	// Use this for initialization
	void Start () {
		//Finding the player this way should make it more compatable between scenes
		playerTransform = GameObject.Find ("PlayerGraphic").transform;

		myTransform = transform;

		mySprite = GetComponent <SpriteRenderer> ();
	}

	// Update is called once per frame
	void Update () {

		if (myTransform.position.y < playerTransform.position.y + rangeVertical && myTransform.position.x < playerTransform.position.x + rangeHorizontal && myTransform.position.x > playerTransform.position.x - rangeHorizontal && myTransform.position.y > playerTransform.position.y) {
<<<<<<< HEAD
			speedVertical = 0;
			Attack();
			mySprite.flipY = false;
		}
		if (myTransform.position.y < playerTransform.position.y - 1) {
			speedVertical = 2;
			mySprite.flipY = false;
		}
		if (myTransform.position.x < playerTransform.position.x + rangeHorizontal && moveDirectionVertical == Vector3.down) {
			moveDirectionHorizontal = Vector3.left;
		}
		if (myTransform.position.x < playerTransform.position.x - rangeHorizontal && moveDirectionVertical == Vector3.down) {
			moveDirectionHorizontal = Vector3.right;
=======
			moveDirectionVertical = Vector3.down;
		}
		if (myTransform.position.y > playerTransform.position.y + rangeVertical && myTransform.position.x < playerTransform.position.x + rangeHorizontal && myTransform.position.x > playerTransform.position.x - rangeHorizontal && myTransform.position.y > playerTransform.position.y) {
			speedVertical = 0;
>>>>>>> origin/master
		}

		myTransform.Translate (moveDirectionVertical * Time.deltaTime * speedVertical);
		myTransform.Translate (moveDirectionHorizontal * Time.deltaTime * speedHorizontal);
<<<<<<< HEAD
	}

	void Attack ()
	{
		
=======
>>>>>>> origin/master
	}
}
