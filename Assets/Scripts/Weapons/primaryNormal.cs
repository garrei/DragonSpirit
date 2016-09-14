using UnityEngine;
using System.Collections;

public class PrimaryNormal : MonoBehaviour {

	int speed = 30;
	Rigidbody2D rb;
	Transform myTransform;

	// Use this for initialization
	void Start () {
		//Need to grab the rigidbody for movement
		rb = GetComponent <Rigidbody2D> ();

		myTransform = transform;
	}
	
	// Update is called once per frame
	void Update () {
		//Moves at a set speed and gets destroyed when it goes up too high
		rb.velocity = new Vector2 (0,speed);
		if (myTransform.position.y > 6.5f) {
			Destroy (gameObject);
		}
	}
}
