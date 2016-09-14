using UnityEngine;
using System.Collections;

public class SecondaryNormal : MonoBehaviour {

	int speed = 8;
	float shrinkSpeed = 1.5f;
	Rigidbody2D rb;
	Collider2D myCollider;
	Transform myTransform;
	float scale;

	// Use this for initialization
	void Start () {

		//Need to grab the rigidbody for the movement
		rb = GetComponent <Rigidbody2D> ();

		//Need to grab the collider for the hit detection
		myCollider = GetComponent <Collider2D> ();
		myTransform = transform;
	}

	// Update is called once per frame
	void Update () {

		//Making the object shrink
		scale = myTransform.localScale.x - shrinkSpeed * Time.deltaTime;
		myTransform.localScale = new Vector2 (scale, scale);

		//Enabling the collider when the object is small enough
		rb.velocity = new Vector2 (0,speed);
		if (myTransform.localScale.x < 0.3f) {
			myCollider.enabled = true;
		}

		//Destroying the object when it is too small
		if (myTransform.localScale.x < 0.2f) {
			Destroy (gameObject);
		}
	}
}
