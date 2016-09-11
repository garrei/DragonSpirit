using UnityEngine;
using System.Collections;

public class primaryNormal : MonoBehaviour {

	int speed = 30;
	Rigidbody2D rb;
	Transform myTransform;

	// Use this for initialization
	void Start () {
		rb = GetComponent <Rigidbody2D> ();
		myTransform = transform;
	}
	
	// Update is called once per frame
	void Update () {
		rb.velocity = new Vector2 (0,speed);
		if (myTransform.position.y > 6.5f) {
			Destroy (gameObject);
		}
	}
}
