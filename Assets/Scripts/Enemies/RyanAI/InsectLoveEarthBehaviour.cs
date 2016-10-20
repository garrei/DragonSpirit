using UnityEngine;
using System.Collections;

public class InsectLoveEarthBehaviour : MonoBehaviour {

	Transform playerTransform;
	Transform myTransform;
	public GameObject myProjectile;
	float shootCooldown = 2;
	Animator anim;
	int altSprite;


	// Use this for initialization
	void Start () {
		anim = GetComponent <Animator> ();
		playerTransform = GameObject.Find ("PlayerGraphic").transform;
		myTransform = transform;
		altSprite = Random.Range (0, 2);
		anim.SetInteger ("altSprite",altSprite);
		Debug.Log (altSprite);
	}

	// Update is called once per frame
	void Update () {
		if (shootCooldown <= Time.time)
		{
			Attack ();
			shootCooldown = Time.time + 2f;
		}

		if (shootCooldown <= Time.time + 0.5f) 
		{
			anim.SetTrigger ("isShoot");
		}

	}

	void Attack ()
	{
			GameObject bullet = (GameObject)Instantiate (myProjectile);
			bullet.transform.position = transform.position;
			Vector2 direction = playerTransform.transform.position - bullet.transform.position;
			bullet.GetComponent<EnemyProjectileTowardsPlayer>().setDirection (direction);
	}
}
