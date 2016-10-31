using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

	public int health = 3;
	float cooldownRate = 3f;
	float nextCool = 0;
	public static float myOpacity = 1;
	Collider2D myCollider;

	void Start (){
		myCollider = GameObject.Find("Player").GetComponent<Collider2D> ();
	}

	// Update is called once per frame
	void Update () {
		if (health < 1){
			Application.LoadLevel (0);
		}
		if(Time.time < nextCool){
			myCollider.enabled = false;
		}
		else{
			if (PlayerController.colliderIsOn == true) {
				myCollider.enabled = true;
			} else {
				myCollider.enabled = false;
			}
		}

		if (myCollider.enabled == false) {
			myOpacity = 0.5f;
		} else {
			myOpacity = 1;
		}
	}

	//This checks whether the bullet should hit the enemy or not depending on it being airbourne or not
	void OnTriggerEnter2D (Collider2D other){
		if(other.CompareTag("EnemyBullet") && Time.time > nextCool){
			Destroy (other.gameObject);
			nextCool = Time.time + cooldownRate;
			health--;
		}
		if(other.CompareTag("Airborne") && Time.time > nextCool){	
			nextCool = Time.time + cooldownRate;
			health--;
		}
	}
}