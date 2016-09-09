using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	Transform myTransform;
	Rigidbody2D rb;
	float speed = 5;
	public bool canMoveLeft = true, canMoveRight = true;
	float movement = 0;

	//Camera
	public Camera cam;
	float camHeight, camWidth;

	// Use this for initialization
	void Start () {
	
		myTransform = transform;
		rb = GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void Update () {
		
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

		//Movement constraints
		//X axis camera constraints
		if(myTransform.position.x > camWidth/2 - camWidth/40){
			myTransform.position = new Vector2 (camWidth/2 - camWidth/40,myTransform.position.y);
			canMoveRight = false;
		}
		if(myTransform.position.x < -camWidth/2 + camWidth/40){
			myTransform.position = new Vector2 (-camWidth/2 + camWidth/40,myTransform.position.y);
			canMoveLeft = false;
		}

		//Y axis camera constraints
		if(myTransform.position.y > camHeight-camHeight/13){
			myTransform.position = new Vector2 (myTransform.position.x,camHeight-camHeight/13);
		}
		if(myTransform.position.y < camHeight/30){
			myTransform.position = new Vector2 (myTransform.position.x,camHeight/30);
		}

		//Fixing the jittering of the terrain
		if (canMoveLeft == false && Input.GetAxisRaw("Horizontal") < 0) {
			movement = 0;
		} 
		else if (canMoveRight == false && Input.GetAxisRaw("Horizontal") > 0) {
			movement = 0;
		} 
		else {
			movement = Input.GetAxisRaw ("Horizontal");
		}
		if(Input.GetAxisRaw("Horizontal") > 0){
			canMoveLeft = true;
		}
		if(Input.GetAxisRaw("Horizontal") < 0){
			canMoveRight = true;
		}

		//Movement
		rb.velocity = new Vector2 (movement*speed, Input.GetAxisRaw("Vertical")*speed);
	}
}
