using UnityEngine;
using System.Collections;

public class OffScreenDestroy : MonoBehaviour {

	Transform myTransform;

	// Use this for initialization
	void Start () {
		myTransform = transform;
	}
	
	// Update is called once per frame
	void Update () {
		
		if(myTransform.position.x > 5 || myTransform.position.x < -5 || myTransform.position.y < -6 || myTransform.position.y > 8){
			Destroy (gameObject);
		}
	}
}
