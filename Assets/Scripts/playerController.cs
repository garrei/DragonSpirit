using UnityEngine;
using System.Collections;

public class playerController : MonoBehaviour {

	Transform myTransform;
	Rigidbody2D rb;
	int speed = 5;

	//Camera
	public Camera cam;
	float camHeight;
	float camWidth;

	// Use this for initialization
	void Start () {
	
		myTransform = transform;
		rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {


		//Movement
		rb.velocity = new Vector2 (Input.GetAxisRaw("Horizontal")*speed, Input.GetAxisRaw("Vertical")*speed);

		//Setting camera constraint variables
		camHeight = 2* cam.orthographicSize;
		camWidth = camHeight * cam.aspect;

		//Camera constraints
		//X axis camera constraints
		if(myTransform.position.x > camWidth/2 - camWidth/40){
			myTransform.position = new Vector2 (camWidth/2 - camWidth/40,myTransform.position.y);
		}
		if(myTransform.position.x < -camWidth/2 + camWidth/40){
			myTransform.position = new Vector2 (-camWidth/2 + camWidth/40,myTransform.position.y);
		}

		//Y axis camera constraints
		if(myTransform.position.y > camHeight-camHeight/13){
			myTransform.position = new Vector2 (myTransform.position.x,camHeight-camHeight/13);
		}
		if(myTransform.position.y < camHeight/30){
			myTransform.position = new Vector2 (myTransform.position.x,camHeight/30);
		}
	}
}
