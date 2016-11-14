using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	Transform myTransform;
	Rigidbody2D rb;
	float currentSpeed, speedNormal = 5, speedDiag;
	public bool canMoveLeft = true, canMoveRight = true;
	float movement = 0;
	public static bool colliderIsOn = true;
	public static bool playerControllerIsBossDead = false;

	// Use this for initialization
	void Start () {
		myTransform = transform;
		rb = GetComponent<Rigidbody2D>();
		speedDiag = speedNormal * 2/3;
		playerControllerIsBossDead = false;
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
		if(myTransform.position.y > 9.25f && playerControllerIsBossDead == false){
			myTransform.position = new Vector2 (myTransform.position.x,9.25f);
		}
		if(myTransform.position.y < 0.4f){
			myTransform.position = new Vector2 (myTransform.position.x,0.4f);
		}

		//Loading next scene after boss is ded
		if(myTransform.position.y > 11 && playerControllerIsBossDead == true){
			if (Application.loadedLevel == 2) {
				playerControllerIsBossDead = false;
				PlayerAttack.playerAttackIsBossDead = false;
				Application.LoadLevel (8);
			} else {
				playerControllerIsBossDead = false;
				PlayerAttack.playerAttackIsBossDead = false;
				Application.LoadLevel (6);
			}
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
		if(Time.time > PlayerHealth.deathNextCool && playerControllerIsBossDead == false){
		rb.velocity = new Vector2 (movement*currentSpeed, Input.GetAxisRaw("Vertical")*currentSpeed);
		}

		//Moving up after murdering a boss
		if(playerControllerIsBossDead == true){
		rb.velocity = new Vector2 (0,0);
		myTransform.Translate (Vector2.up * speedNormal * Time.deltaTime);
		}

		//Turning collider off with Spacebar
		if(Input.GetKeyDown(KeyCode.Space) && colliderIsOn == true){
			colliderIsOn = false;
		} else
		if(Input.GetKeyDown(KeyCode.Space) && colliderIsOn == false){
			colliderIsOn = true;
		}
	}
}
