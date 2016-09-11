using UnityEngine;
using System.Collections;

public class secondaryNormal : MonoBehaviour {

	int speed = 10;
	float shrinkSpeed = 1.5f;
	Rigidbody2D rb;
	Collider2D myCollider;
	Transform myTransform;
	float scale;

	// Use this for initialization
	void Start () {
		rb = GetComponent <Rigidbody2D> ();
		myCollider = GetComponent <Collider2D> ();
		myTransform = transform;
	}

	// Update is called once per frame
	void Update () {
		scale = myTransform.localScale.x - shrinkSpeed * Time.deltaTime;
		myTransform.localScale = new Vector2 (scale, scale);
		rb.velocity = new Vector2 (0,speed);
		if (myTransform.localScale.x < 0.3f) {
			myCollider.enabled = true;
		}
		if (myTransform.localScale.x < 0.2f) {
			Destroy (gameObject);
		}
	}
}
