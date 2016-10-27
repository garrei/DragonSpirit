using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

	public GameObject enemyToSpawn;
	Transform myTransform;
	public int spawnPosition = 7;

	// Use this for initialization
	void Start () {
		myTransform = transform;
	}
	
	// Update is called once per frame
	void Update () {

		if(myTransform.position.y < spawnPosition && myTransform.position.y > spawnPosition - 3){
			Instantiate (enemyToSpawn, myTransform.position, Quaternion.identity);
			Destroy (gameObject);
		}
	}
}
