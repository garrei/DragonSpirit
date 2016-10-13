using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

	public GameObject enemyToSpawn;
	SpriteRenderer mySpriteRenderer;
	SpriteRenderer enemySpriteRenderer;
	Transform myTransform;

	// Use this for initialization
	void Start () {
		myTransform = transform;

		//Using a SpriteRenderer to visually show what enemy is being spawned
		mySpriteRenderer = GetComponent <SpriteRenderer> ();

		//We need to find the SpriteRenderer of the enemy to show what is being spawned
		enemySpriteRenderer = enemyToSpawn.GetComponent<SpriteRenderer> ();

		mySpriteRenderer.sprite = enemySpriteRenderer.sprite;
	
	}
	
	// Update is called once per frame
	void Update () {

		if(myTransform.position.y < 7){
			Instantiate (enemyToSpawn, myTransform.position, Quaternion.identity);
			Destroy (gameObject);
		}
	
	}
}
