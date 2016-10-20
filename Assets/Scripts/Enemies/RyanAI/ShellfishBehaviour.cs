using UnityEngine;
using System.Collections;

public class ShellfishBehaviour : MonoBehaviour {

	Transform playerTransform;
	Transform cameraTransform;
	Transform myTransform;
	float speedVertical = 5f;
	Vector2 _direction;
	Animator anim;
	bool gliding = false;
	Vector3 bulletPosition;
	Vector3 moveDirectionVertical = Vector3.up;
	SpriteRenderer mySprite;

	// Use this for initialization
	void Start () {
		//Finding the player this way should make it more compatable between scenes
		playerTransform = GameObject.Find ("PlayerGraphic").transform;
		cameraTransform = GameObject.Find ("LetterboxCam").transform;
		myTransform = transform;
		anim = GetComponent <Animator> ();
		mySprite = GetComponent <SpriteRenderer> ();



	}

	// Update is called once per frame
	void Update () 
	{
		myTransform.Translate (moveDirectionVertical * Time.deltaTime * speedVertical);

		if (myTransform.position.y > cameraTransform.position.y + 4.5f) 
		{
			anim.SetBool ("Underwater", false);
			gameObject.tag = "Airborne";
			speedVertical = -5f;
		}


			
	}
		
}
