using UnityEngine;
using System.Collections;

public class RoundPhoenixBehaviour : MonoBehaviour {

	Transform myTransform;
	Vector3 moveDirectionHorizontal;
	Vector3 moveDirectionVertical;
	int speedHorizontal = 5;
	int speedVertical = 3;
	int randomInt;
	public int maximumX;
	public int minY;
	public int maxY;
	SpriteRenderer mySpriteRenderer;

	// Use this for initialization
	void Start () {
		mySpriteRenderer = GetComponent <SpriteRenderer> ();

		myTransform = transform;

		randomInt = Random.Range (0,2);

		//Setting a random initial direction
		if (randomInt == 0) {
			moveDirectionHorizontal = Vector2.left;
			moveDirectionVertical = Vector3.up;
		} else {
			moveDirectionHorizontal = Vector2.right;
			moveDirectionVertical = Vector3.down;
		}
	}

	// Update is called once per frame
	void Update () {
		randomInt = Random.Range (0,2);

		if(myTransform.position.x >= maximumX){
			moveDirectionHorizontal = Vector2.left;
		}

		if(myTransform.position.x <= -maximumX){
			moveDirectionHorizontal = Vector2.right;
		}

		if(myTransform.position.y >= maxY){
			moveDirectionVertical = Vector2.down;
			if (randomInt == 0) {
				moveDirectionHorizontal = Vector3.left;
			} else {
				moveDirectionHorizontal = Vector3.right;
			}
		}

		if(myTransform.position.y <= minY){
			moveDirectionVertical = Vector2.up;
			if (randomInt == 0) {
				moveDirectionHorizontal = Vector3.left;
			} else {
				moveDirectionHorizontal = Vector3.right;
			}
		}

		//Setting the direction of the sprite

		if(moveDirectionVertical == Vector3.down){
			mySpriteRenderer.flipY = false;
		}


		if(moveDirectionVertical == Vector3.up){
			mySpriteRenderer.flipY = true;
		}

		myTransform.Translate (moveDirectionHorizontal * speedHorizontal * Time.deltaTime);
		myTransform.Translate (moveDirectionVertical * speedVertical * Time.deltaTime);
	}
}