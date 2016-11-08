using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

	Transform myTransform;
	public static int health = 3;
	public static int lives = 3;
	float hitCooldownRate = 3f;
	float hitNextCool = 0;
	float deathCooldownRate = 3f;
	public static float deathNextCool = 0;
	public static float myOpacity = 1;
	Collider2D myCollider;
	public static bool mySpriteEnabled = true;
	//public GameObject myExplosion;
	public AudioSource MainAudioSource;
	public AudioClip PlayerHitSound;

	void Start (){
		myTransform = transform;
		myCollider = GameObject.Find("Player").GetComponent<Collider2D> ();
	}

	// Update is called once per frame
	void Update () {

		//What happens when you run out of health
		if (health < 1){
			lives--;
			health = 3;
			deathNextCool = Time.time + deathCooldownRate;
			hitNextCool = Time.time + deathCooldownRate + hitCooldownRate;

			//Resetting powerups
			PlayerAttack.fireRate1 = 0.15f;
			PlayerAttack.fireRate2 = 1f;
			PlayerHeads.powerLevel = 0;

			//Instantiate (myExplosion, myTransform.position, Quaternion.identity);
		}

		//What happens when you run out of lives
		if(lives < 1){
			Application.LoadLevel (4);
			lives = 3;
			health = 3;
		}

		//Determines whether the hit cooldown is active
		if(Time.time < hitNextCool){
			myCollider.enabled = false;
		}
		else{
			if (PlayerController.colliderIsOn == true) {
				myCollider.enabled = true;
			} else {
				myCollider.enabled = false;
			}
		}
		//Sets the opacity of the sprite during cooldown
		if (myCollider.enabled == false) {
			myOpacity = 0.5f;
		} else {
			myOpacity = 1;
		}

		//Determines whether the death cooldown is active
		if(Time.time < deathNextCool){
			myCollider.enabled = false;
			mySpriteEnabled = false;
		}
		else{
			if (PlayerController.colliderIsOn == true) {
				myCollider.enabled = true;
			} else {
				myCollider.enabled = false;
			}
			mySpriteEnabled = true;
		}
	}

	//This checks whether the bullet should hit the enemy or not depending on it being airbourne or not
	void OnTriggerEnter2D (Collider2D other){
		if(other.CompareTag("EnemyBullet") && Time.time > hitNextCool){
			Destroy (other.gameObject);
			hitNextCool = Time.time + hitCooldownRate;
			health--;
			MainAudioSource.PlayOneShot (PlayerHitSound);
		}
		if(other.CompareTag("Airborne") && Time.time > hitNextCool){	
			hitNextCool = Time.time + hitCooldownRate;
			health--;
			MainAudioSource.PlayOneShot (PlayerHitSound);
		}
		if(other.CompareTag("LavaPlume") && Time.time > hitNextCool){	
			hitNextCool = Time.time + hitCooldownRate;
			health--;
			MainAudioSource.PlayOneShot (PlayerHitSound);
		}
	}
}