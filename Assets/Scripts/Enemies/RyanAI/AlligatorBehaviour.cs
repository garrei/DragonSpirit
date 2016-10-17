using UnityEngine;
using System.Collections;

public class AlligatorBehaviour : MonoBehaviour {

	Transform playerTransform;
	Transform myTransform;

	public GameObject myProjectile;
	float shootCooldown;
	float speedVertical = 1.5f;
	float rangeVertical = 4;
	float rangeHorizontal = 10f;

	Vector3 bulletPosition;
	Vector3 moveDirectionVertical = Vector3.down;
	SpriteRenderer mySprite;

	// Use this for initialization
	void Start () {
		//Finding the player this way should make it more compatable between scenes
		playerTransform = GameObject.Find ("PlayerGraphic").transform;

		myTransform = transform;

		mySprite = GetComponent <SpriteRenderer> ();


	}

	// Update is called once per frame
	void Update () {

		if (myTransform.position.y < playerTransform.position.y + rangeVertical && myTransform.position.x < playerTransform.position.x + rangeHorizontal && myTransform.position.x > playerTransform.position.x - rangeHorizontal && myTransform.position.y > playerTransform.position.y) {

			speedVertical = 0;
			Attack();
			mySprite.flipY = false;
		}
		if (myTransform.position.y < playerTransform.position.y - 1) {
			speedVertical = 1.5f;
			mySprite.flipY = false;
		}

		myTransform.Translate (moveDirectionVertical * Time.deltaTime * speedVertical);
		bulletPosition = new Vector3(transform.position.x, transform.position.y - 0.5f);
	}

	void Attack ()
	{
		if (shootCooldown <= Time.time)
		{
			//Animator Script for attacking Will Go Here
			GameObject bullet = (GameObject)Instantiate (myProjectile);
			bullet.transform.position = bulletPosition;
			Vector2 direction = playerTransform.transform.position - bullet.transform.position;
			bullet.GetComponent<EnemyProjectileTowardsPlayer>().setDirection (direction);
	
			shootCooldown = Time.time + 2f;
		}

	}
}
