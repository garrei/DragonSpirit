using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

	public GameObject enemyToSpawn;
	Transform myTransform;
	public bool onlySpawnHardMode = false;
	public int spawnPosition = 7;

	// Use this for initialization
	void Start () {
		myTransform = transform;
	}
	
	// Update is called once per frame
	void Update () {

		if (Buttons.hardMode == false) 
			{
				if (myTransform.position.y < spawnPosition && myTransform.position.y > spawnPosition - 3 && onlySpawnHardMode == false) 
				{
					Instantiate (enemyToSpawn, myTransform.position, Quaternion.identity);
					Destroy (gameObject);
				} 
			} 
			else 
			{
				if (myTransform.position.y < spawnPosition && myTransform.position.y > spawnPosition - 3) 
				{
					Instantiate (enemyToSpawn, myTransform.position, Quaternion.identity);
					Destroy (gameObject);
				} 
			}
			
	}

}
