using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	Transform myTransform;
	Rigidbody2D rb;
	float currentSpeed, speedNormal = 5, speedDiag;
	public bool canMoveLeft = true, canMoveRight = true;
	float movement = 0;
	public static int playerScore = 0;
	bool colliderIsOn = true;
	BoxCollider2D myCollider;

	// Use this for initialization
	void Start () {
		myTransform = transform;
		rb = GetComponent<Rigidbody2D>();
		speedDiag = speedNormal * 2/3;
		myCollider = GetComponent<BoxCollider2D> ();
	}

	// Update is called once per frame
	void Update () {
		
		//When both axes are called at the same time the player wil move slightly faster
		//This can be fixed by changing the speed when this occurs
		if(Input.GetAxisRaw ("Vertical") == 1 && Input.GetAxisRaw ("Horizontal") == 1){
			currentSpeed = speedDiag;
		}
		else if(Input.GetAxisRaw ("Vertical") == 1 && Input.GetAxisRaw ("Horizontal") == -1){
			currentSpeed = speedDiag;
		}
		else if(Input.GetAxisRaw ("Vertical") == -1 && Input.GetAxisRaw ("Horizontal") == 1){
			currentSpeed = speedDiag;
		}
		else if(Input.GetAxisRaw ("Vertical") == 1 && Input.GetAxisRaw ("Horizontal") == 1){
			currentSpeed = speedDiag;
		}
		else if(Input.GetAxisRaw ("Vertical") == -1 && Input.GetAxisRaw ("Horizontal") == -1){
			currentSpeed = speedDiag;
		}
		else {
			currentSpeed = speedNormal;
		}

		//Movement constraints
		//X axis camera constraints
		if(myTransform.position.x > 3.7f){
			myTransform.position = new Vector2 (3.7f,myTransform.position.y);
			canMoveRight = false;
		}
		if(myTransform.position.x < -3.7f){
			myTransform.position = new Vector2 (-3.7f,myTransform.position.y);
			canMoveLeft = false;
		}

		//Y axis camera constraints
		if(myTransform.position.y > 9.25f){
			myTransform.position = new Vector2 (myTransform.position.x,9.25f);
		}
		if(myTransform.position.y < 0.4f){
			myTransform.position = new Vector2 (myTransform.position.x,0.4f);
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
		rb.velocity = new Vector2 (movement*currentSpeed, Input.GetAxisRaw("Vertical")*currentSpeed);

		//Turning collider off with Spacebar
		if(Input.GetKeyDown(KeyCode.Space) && colliderIsOn == true){
			myCollider.enabled = false;
			colliderIsOn = false;
		} else
		if(Input.GetKeyDown(KeyCode.Space) && colliderIsOn == false){
			myCollider.enabled = true;
			colliderIsOn = true;
		}

		Debug.Log (colliderIsOn);
	}
}
