using UnityEngine;
using System.Collections;

public class EnemyProjectile : MonoBehaviour {

	Transform myTransform;
	public float bulletSpeed = 5;

	// Use this for initialization
	void Start () {
		myTransform = transform;
	}
	
	// Update is called once per frame
	void Update () {
		myTransform.Translate (Vector3.down * bulletSpeed * Time.deltaTime);
	}
}
