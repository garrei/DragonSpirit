using UnityEngine;
using System.Collections;

public class TyrannosaurusBehaviour : MonoBehaviour {

	Transform playerTransform;
	Transform myTransform;
	public GameObject myProjectile;
	float shootCooldown = 2;
	float shootAnimCooldown;
	bool isShoot;
	int direction;
	Vector3 bulletPosition;
	Animator anim;
	SpriteRenderer mySprite;

	// Use this for initialization
	void Start () {
		
		playerTransform = GameObject.Find ("PlayerGraphic").transform;
		myTransform = transform;
		bulletPosition = new Vector3(transform.position.x, transform.position.y);
		anim = GetComponent <Animator> ();
		anim.SetInteger ("direction",0);


		mySprite = GetComponent <SpriteRenderer> ();


	}

	// Update is called once per frame
	void Update () {
		if (shootCooldown <= Time.time)
		{
			Attack ();
			shootCooldown = Time.time + 2f;
		}
			
		//if player is far enough to the right of the enemy
		if (playerTransform.position.x - myTransform.position.x >= 0.5f) {
			bulletPosition = new Vector3 (transform.position.x + 0.3f, transform.position.y);
			anim.SetInteger ("direction", 1);

			mySprite.flipX = false;

		} else {
			mySprite.flipX = true;
		}

		//if the player is far enough to the left of the enemy
		if (playerTransform.position.x - myTransform.position.x <= -0.5f)
		{
			bulletPosition = new Vector3(transform.position.x - 0.3f, transform.position.y);
			anim.SetInteger ("direction",1);

		}

		//if the player is in front of the enemy
		if (playerTransform.position.x - myTransform.position.x >= -0.5f && playerTransform.position.x - myTransform.position.x <= 0.5f)
		{
			bulletPosition = new Vector3(transform.position.x, transform.position.y - 0.2f);
			anim.SetInteger ("direction",0);

		}
	}
		

	void Attack ()
	{
			anim.SetTrigger ("isShoot");
			GameObject bullet = (GameObject)Instantiate (myProjectile);
			bullet.transform.position = bulletPosition;
			Vector2 direction = playerTransform.transform.position - bullet.transform.position;
			bullet.GetComponent<EnemyProjectileTowardsPlayer>().setDirection (direction);
	}
}
