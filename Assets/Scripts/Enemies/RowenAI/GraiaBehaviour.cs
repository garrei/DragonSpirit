using UnityEngine;
using System.Collections;

public class GraiaBehaviour : MonoBehaviour {

	Transform playerTransform;
	Transform myTransform;
	int speedVertical = 7;
	int speedHorizontal = 2;
	float rangeHorizontal = 1.5f;
	Vector3 moveDirectionHorizontal = Vector3.right;

	// Use this for initialization
	void Start () {
		//Finding the player this way should make it more compatable between scenes
		playerTransform = GameObject.Find ("PlayerGraphic").transform;

		myTransform = transform;
	}

	// Update is called once per frame
	void Update () {

		if (myTransform.position.x < playerTransform.position.x + rangeHorizontal && myTransform.position.y > playerTransform.position.y) {
			moveDirectionHorizontal = Vector3.left;
		}
		if (myTransform.position.x < playerTransform.position.x - rangeHorizontal && myTransform.position.y > playerTransform.position.y) {
			moveDirectionHorizontal = Vector3.right;
		}

		myTransform.Translate (Vector3.down* Time.deltaTime * speedVertical);
		myTransform.Translate (moveDirectionHorizontal * Time.deltaTime * speedHorizontal);
	}
}
