using UnityEngine;
using System.Collections;

public class SparklerBehaviour : MonoBehaviour {

	Transform playerTransform;
	Transform myTransform;
	float speedVertical = 1;
	float speedHorizontal = 4;
	Vector3 moveDirectionVertical = Vector3.up;
	Vector3 moveDirectionHorizontal = Vector3.right;

	// Use this for initialization
	void Start () 
	{
		myTransform = transform;
		playerTransform = GameObject.Find ("PlayerGraphic").transform;
		if (myTransform.position.x < playerTransform.position.x) 
		{
			moveDirectionHorizontal = Vector3.right;
		}
		else if (myTransform.position.x > playerTransform.position.x)
		{
			moveDirectionHorizontal = Vector3.left;
		}

	}
	
	// Update is called once per frame
	void Update () 
	{
		speedVertical = speedVertical + Time.deltaTime * 2f;
		speedHorizontal = speedHorizontal - Time.deltaTime * 2f;



		myTransform.Translate (moveDirectionVertical * Time.deltaTime * speedVertical);
		myTransform.Translate (moveDirectionHorizontal * Time.deltaTime * speedHorizontal);
	
	}
}
