using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	Transform myTransform;
	Rigidbody2D rb;
	float speed = 5;

	//Camera
	public Camera cam;
	float camHeight;
	float camWidth;

	// Use this for initialization
	void Start () {
	
		myTransform = transform;
		rb = GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void Update () {
		
		//Movement
		rb.velocity = new Vector2 (Input.GetAxisRaw("Horizontal")*speed, Input.GetAxisRaw("Vertical")*speed);

		//When both axes are called at the same time the player wil move slightly faster
		//THis can be fixed by changing the speed when this occurs
		if(Input.GetAxisRaw ("Vertical") == 1 && Input.GetAxisRaw ("Horizontal") == 1){
			speed = 3.375f;
		}
		else if(Input.GetAxisRaw ("Vertical") == 1 && Input.GetAxisRaw ("Horizontal") == -1){
			speed = 3.375f;
		}
		else if(Input.GetAxisRaw ("Vertical") == -1 && Input.GetAxisRaw ("Horizontal") == 1){
			speed = 3.375f;
		}
		else if(Input.GetAxisRaw ("Vertical") == 1 && Input.GetAxisRaw ("Horizontal") == 1){
			speed = 3.375f;
		}
		else if(Input.GetAxisRaw ("Vertical") == -1 && Input.GetAxisRaw ("Horizontal") == -1){
			speed = 3.375f;
		}
		else {
			speed = 5f;
		}

		//Setting camera constraint variables
		camHeight = 2* cam.orthographicSize;
		camWidth = camHeight * cam.aspect;

		//Camera constraints
		//X axis camera constraints
		if(myTransform.position.x > camWidth/2 - camWidth/40){
			myTransform.position = new Vector2 (camWidth/2 - camWidth/40,myTransform.position.y);
		}
		if(myTransform.position.x < -camWidth/2 + camWidth/40){
			myTransform.position = new Vector2 (-camWidth/2 + camWidth/40,myTransform.position.y);
		}

		//Y axis camera constraints
		if(myTransform.position.y > camHeight-camHeight/13){
			myTransform.position = new Vector2 (myTransform.position.x,camHeight-camHeight/13);
		}
		if(myTransform.position.y < camHeight/30){
			myTransform.position = new Vector2 (myTransform.position.x,camHeight/30);
		}
	}
}
