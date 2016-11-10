using UnityEngine;
using System.Collections;

public class BioCyclerRocks : MonoBehaviour {
	
	public Transform rotatePoint;
	Transform myTransform;
	public float rotateSpeed = 50f;

	// Use this for initialization
	void Start () 
	{
		myTransform = transform;
	}
	
	// Update is called once per frame
	void Update () 
	{
		myTransform.position = new Vector2 (myTransform.position.x,myTransform.position.y);
		rotatePoint.Rotate (Vector3.forward * rotateSpeed * Time.deltaTime);

	}
}
