using UnityEngine;
using System.Collections;

public class TerrainMove : MonoBehaviour {

	bool terrainIsMoving = true;
	public static float speed = 0.5f;
	Transform myTransform;
	GameObject player;

	// Use this for initialization
	void Start () {
		myTransform = transform;
		player = GameObject.Find ("PlayerGraphic");
	}

	// Update is called once per frame
	void Update () {

		//Object moves down at a constant speed
		if(terrainIsMoving == true && myTransform.position.y > 1){
			if(Time.time > PlayerHealth.deathNextCool){
			myTransform.Translate (Vector3.down *speed * Time.deltaTime);
			}
		}

		if(myTransform.position.y < 1){
			myTransform.position = new Vector2 (myTransform.position.x, 1);
		}

		//This moves the terrain in the opposite direction that the player is moving
		//Used the negative of the player's position to stay consistent
		myTransform.position = new Vector3(-player.transform.position.x/2.6f,myTransform.position.y,myTransform.position.z);
	}
}