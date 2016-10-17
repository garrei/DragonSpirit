using UnityEngine;
using System.Collections;

public class InsectLoveEarthBehaviour : MonoBehaviour {

	Transform playerTransform;
	Transform myTransform;
	public GameObject myProjectile;
	float shootCooldown;


	// Use this for initialization
	void Start () {
		
		playerTransform = GameObject.Find ("PlayerGraphic").transform;
		myTransform = transform;
	}

	// Update is called once per frame
	void Update () {
		if (shootCooldown <= Time.time)
		{
			Attack ();
			shootCooldown = Time.time + 2f;
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
