using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

	public GameObject enemyToSpawn;
	Transform myTransform;

	// Use this for initialization
	void Start () {
		myTransform = transform;
	}
	
	// Update is called once per frame
	void Update () {

		if(myTransform.position.y < 8f){
			Instantiate (enemyToSpawn, myTransform.position, Quaternion.identity);
			Destroy (gameObject);
		}
	}
}
