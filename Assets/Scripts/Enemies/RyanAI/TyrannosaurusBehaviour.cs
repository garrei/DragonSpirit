using UnityEngine;
using System.Collections;

public class TyrannosaurusBehaviour : MonoBehaviour {

	Transform playerTransform;
	Transform myTransform;
	public GameObject myProjectile;
	float shootCooldown;
	Vector3 bulletPosition;


	// Use this for initialization
	void Start () {
		
		playerTransform = GameObject.Find ("PlayerGraphic").transform;
		myTransform = transform;
		bulletPosition = new Vector3(transform.position.x, transform.position.y - 0.0f);
		//change bulletposition float to change where the bullet originates
	}

	// Update is called once per frame
	void Update () {
		if (shootCooldown <= Time.time)
		{
			Attack ();
			shootCooldown = Time.time + 2f;
		}


		//if player is far enough to the right of the enemy
		if (playerTransform.position.x - myTransform.position.x >= 3)
		{
			bulletPosition = new Vector3(transform.position.x, transform.position.y - 0.0f);
			//change bulletposition float to change bullet origin point
			//Change to Sprite for this direction to face right
		}

		//if the player is far enough to the left of the enemy
		if (playerTransform.position.x - myTransform.position.x >= -3)
		{
			bulletPosition = new Vector3(transform.position.x, transform.position.y - 0.0f);
			//change bulletposition float to change bullet origin point
			//Change to Sprite for this direction to face left
		}

		//if the player is in front of the enemy
		if (playerTransform.position.x - myTransform.position.x >= -3 && playerTransform.position.x - myTransform.position.x <= 3)
		{
			bulletPosition = new Vector3(transform.position.x, transform.position.y - 0.0f);
			//change bulletposition float to change bullet origin point
			//Change to Sprite for this direction to face forwards
		}
			
	}
		

	void Attack ()
	{
		if (shootCooldown <= Time.time)
		{
			//Animator Script for attacking Will Go Here
			GameObject bullet = (GameObject)Instantiate (myProjectile);
			bullet.transform.position = transform.position;
			Vector2 direction = playerTransform.transform.position - bullet.transform.position;
			bullet.GetComponent<EnemyProjectileTowardsPlayer>().setDirection (direction);

			shootCooldown = Time.time + 2f;
		}

	}
}
