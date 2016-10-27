using UnityEngine;
using System.Collections;

public class AquasaurusBehaviour : MonoBehaviour {

	Transform playerTransform;
	Transform myTransform;

	public GameObject myProjectile;
	float shootCooldown = 4;
	float speedVertical = 0.1f;
	float speedHorizontal = 1;
	bool isLeft = false;
	float directionTimer = 0;
	Vector3 bulletPosition;
	Vector3 moveDirectionVertical = Vector3.down;
	Vector3 moveDirectionHorizontal = Vector3.left;
	SpriteRenderer mySprite;
	Animator anim;

	// Use this for initialization
	void Start () {
		
		//Finding the player this way should make it more compatable between scenes
		playerTransform = GameObject.Find ("PlayerGraphic").transform;
		myTransform = transform;
		mySprite = GetComponent <SpriteRenderer> ();
		anim = GetComponent <Animator> ();
	}

	// Update is called once per frame
	void Update () {

		directionTimer = directionTimer + Time.deltaTime;

		if (directionTimer >= 5) 
		{
			isLeft = !isLeft;
			directionTimer = 0;
		}

		if (isLeft == true) 
		{
			speedHorizontal = 0.2f;
			mySprite.flipX = false;
			bulletPosition = new Vector3(transform.position.x - 0.35f, transform.position.y);
		}

		if (isLeft == false) 
		{
			speedHorizontal = -0.2f;
			mySprite.flipX = true;
			bulletPosition = new Vector3(transform.position.x + 0.35f, transform.position.y);
		}
		if (shootCooldown <= Time.time)
		{
			Attack ();
			shootCooldown = Time.time + 4f;
		}

		myTransform.Translate (moveDirectionHorizontal * Time.deltaTime * speedHorizontal);
		myTransform.Translate (moveDirectionVertical * Time.deltaTime * speedVertical);

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
