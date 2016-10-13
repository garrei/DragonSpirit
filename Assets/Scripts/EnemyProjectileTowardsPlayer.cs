using UnityEngine;
using System.Collections;

public class EnemyProjectileTowardsPlayer : MonoBehaviour {

	float speed;
	Vector2 _direction;

	// Use this for initialization

	//Method for the bullets direction - referanced by enemy script
	public void setDirection(Vector2 direction)
	{
		_direction = direction.normalized;

	}



	void Start () 
	{
		speed = 4f;
	}
	
	// Update is called once per frame
	void Update () 
	{
			Vector2 position = transform.position;
			position += _direction * speed * Time.deltaTime;
			transform.position = position;
	}
}
