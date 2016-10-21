using UnityEngine;
using System.Collections;

public class OrbMove : MonoBehaviour {

	float speedVertical = 0.5f;
	Transform myTransform;

	// Use this for initialization
	void Start () 
	{
		myTransform = transform;
	}
	
	// Update is called once per frame
	void Update () 
	{
		myTransform.Translate (Vector3.down * Time.deltaTime * speedVertical);
	}
}
