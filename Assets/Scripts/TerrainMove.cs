using UnityEngine;
using System.Collections;

public class TerrainMove : MonoBehaviour {

	bool terrainIsMoving = true;
	float speed = 0.5f;
	Transform myTransform;
	public GameObject player;

	// Use this for initialization
	void Start () {
		myTransform = transform;
	}

	// Update is called once per frame
	void Update () {

		//Object moves down at a constant speed
		if(terrainIsMoving == true){
			myTransform.Translate (Vector3.down *speed * Time.deltaTime);
		}

		//This moves the terrain in the opposite direction that the player is moving
		//Used the negative of the player's position to stay consistent
		myTransform.position = new Vector3(-player.transform.position.x/4,myTransform.position.y,myTransform.position.z);
	}
}
