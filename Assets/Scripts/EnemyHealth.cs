using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {

	public int health = 1;
	public bool isGrounded = false;
	public int score = 0;
	public GameObject spawnOnDeath;
	Transform myTransform;
	GameObject myTerrain;

	// Update is called once per frame
	void Start (){
		myTransform = transform;
		myTerrain = GameObject.Find ("Terrain");
	}

	void Update () {

		if (health < 1 && myTransform.parent == null){
			OnDeath ();
			Destroy (gameObject);
		} else
			if (health < 1 && myTransform.parent.parent != null){
				OnDeath ();
				if(gameObject.transform.parent.parent.gameObject != myTerrain){
				Destroy (gameObject.transform.parent.parent.gameObject);
				}
				if(gameObject.transform.parent.parent.gameObject == myTerrain){
					Destroy (gameObject.transform.parent.gameObject);
				}
			} else
				if (health < 1 && myTransform.parent != null){
					OnDeath ();
					if(gameObject.transform.parent.gameObject != myTerrain){
					Destroy (gameObject.transform.parent.gameObject);
					}
					if(gameObject.transform.parent.gameObject == myTerrain){
						Destroy (gameObject);
					}
				}
	}

	void OnDeath (){
		PlayerController.playerScore += score;
		Instantiate (spawnOnDeath, myTransform.position,Quaternion.identity);
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
