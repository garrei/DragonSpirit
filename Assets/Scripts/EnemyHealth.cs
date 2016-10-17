using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {

	public int health = 1;
	public bool isGrounded = false;
	public int score = 0;
	Transform myTransform;
	
	// Update is called once per frame
	void Start (){
		myTransform = transform;
	}

	void Update () {
		
		if (health < 1 && myTransform.parent == null){
			PlayerController.playerScore += score;
			Destroy (gameObject);
		}
		if (health < 1 && myTransform.parent == true){
			PlayerController.playerScore += score;
			Destroy (myTransform.parent.parent);
		}
	}
		
	//This checks whether the bullet should hit the enemy or not depending on it being airbourne or not
	void OnTriggerEnter2D (Collider2D other){
		if(other.CompareTag("WeaponForward") && isGrounded == false){
			health--;
		}
		if(other.CompareTag("WeaponDown") && isGrounded == true){
			health--;
		}
	}
}
