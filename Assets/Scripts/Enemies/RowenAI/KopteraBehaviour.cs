using UnityEngine;
using System.Collections;

public class KopteraBehaviour : MonoBehaviour {

	Transform playerTransform;
	Transform myTransform;
	int speedVertical = 7;
	int speedHorizontal = 2;
	Vector3 moveDirectionVertical = Vector3.down;
	Vector3 moveDirectionHorizontal = Vector3.right;

	// Use this for initialization
	void Start () {
		//Finding the player this way should make it more compatable between scenes
		playerTransform = GameObject.Find ("PlayerGraphic").transform;

		myTransform = transform;
	}

	// Update is called once per frame
	void Update () {

		if (myTransform.position.y < playerTransform.position.y + 1.5) {
			moveDirectionVertical = Vector3.up;
		}
		if (myTransform.position.x < playerTransform.position.x + 1.5 && moveDirectionVertical == Vector3.down) {
			moveDirectionHorizontal = Vector3.left;
		}
		if (myTransform.position.x < playerTransform.position.x - 1.5 && moveDirectionVertical == Vector3.down) {
			moveDirectionHorizontal = Vector3.right;
		}

		myTransform.Translate (moveDirectionVertical * Time.deltaTime * speedVertical);
		myTransform.Translate (moveDirectionHorizontal * Time.deltaTime * speedHorizontal);
	}
}
