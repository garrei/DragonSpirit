using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

	public int health = 3;

	// Update is called once per frame
	void Update () {
		if (health < 1){
			Destroy (gameObject);
		}
	}

	//This checks whether the bullet should hit the enemy or not depending on it being airbourne or not
	void OnTriggerEnter2D (Collider2D other){
		if(other.CompareTag("EnemyBullet")){
			health--;
		}
	}
}