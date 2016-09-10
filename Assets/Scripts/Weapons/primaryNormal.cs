using UnityEngine;
using System.Collections;

public class primaryNormal : MonoBehaviour {

	int speed = 30;
	Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent <Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		rb.velocity = new Vector2 (0,speed);
		Destroy (gameObject,0.5f);
	}
}
