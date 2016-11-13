using UnityEngine;
using System.Collections;

public class BioCyclerBehaviour : MonoBehaviour {

	Transform playerTransform;
	Transform myTransform;
	int speedVertical = 1;
	int speedHorizontal = 1;
	int rangeVertical = 2;
	float rangeHorizontal = 0.5f;
	float shootCooldown = 1;
	public GameObject myProjectile;
	Vector3 moveDirectionVertical = Vector3.down;
	Vector3 moveDirectionHorizontal = Vector3.right;
	SpriteRenderer mysprite;
	int movement;

	// Use this for initialization
	void Start () {
		//Finding the player this way should make it more compatable between scenes
		playerTransform = GameObject.Find ("PlayerGraphic").transform;
		mysprite = GetComponent<SpriteRenderer> ();
		myTransform = transform;
		movement = Random.Range (0, 2);
	}

	// Update is called once per frame
	void Update () {


		if (movement == 1) 
		{
			moveDirectionHorizontal = Vector3.left;
		}

		if (movement == 2) 
		{
			moveDirectionHorizontal = Vector3.right;
		}
			

		myTransform.Translate (moveDirectionVertical * Time.deltaTime * speedVertical);
		myTransform.Translate (moveDirectionHorizontal * Time.deltaTime * speedHorizontal);

		if (shootCooldown <= Time.time)
		{
			Attack ();
			shootCooldown = Time.time + 1f;
			movement = Random.Range (0, 2);
		}

	}

	void Attack ()
	{
		Instantiate (myProjectile, myTransform.position, Quaternion.identity);

	}
}