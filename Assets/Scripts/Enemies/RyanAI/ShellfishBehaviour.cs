using UnityEngine;
using System.Collections;

public class ShellfishBehaviour : MonoBehaviour {

	Transform playerTransform;
	Transform myTransform;

	float speed;
	Vector2 _direction;
	Animator anim;
	bool gliding = false;
	Vector3 bulletPosition;
	Vector3 moveDirectionVertical = Vector3.down;
	SpriteRenderer mySprite;

	// Use this for initialization
	void Start () {
		//Finding the player this way should make it more compatable between scenes
		playerTransform = GameObject.Find ("PlayerGraphic").transform;
		myTransform = transform;
		anim = GetComponent <Animator> ();
		mySprite = GetComponent <SpriteRenderer> ();
		speed = 5f;


	}

	// Update is called once per frame
	void Update () {

		if (myTransform.position.y < playerTransform.position.y + 7) 
		{
			gliding = true;
		}

		if (gliding == true)
		{
			anim.SetBool ("Gliding", true);
			gameObject.tag = "Airborne";
			Vector2 position = transform.position;
			position += _direction * speed * Time.deltaTime;
			transform.position = position;
		}
		if (gliding == false) 
		{
			Vector2 direction = playerTransform.transform.position - myTransform.position;
			_direction = direction.normalized;
		}

			
	}
		
}
