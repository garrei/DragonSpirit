using UnityEngine;
using System.Collections;

public class TerrainMove : MonoBehaviour {

	bool terrainIsMoving = true;
	Transform myTransform;

	// Use this for initialization
	void Start () {
		myTransform = transform;
	}
	
	// Update is called once per frame
	void Update () {
		if(terrainIsMoving == true){
			myTransform.Translate (Vector3.down/100);
		}
	}
}
