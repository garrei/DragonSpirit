using UnityEngine;
using System.Collections;

public class InstantiateAsChild : MonoBehaviour {

	Transform myTransform;

	// Use this for initialization
	void Start () {
		myTransform = transform;
		if (GameObject.Find ("Terrain") != null) {
			myTransform.parent = GameObject.Find ("Terrain").transform;
		} else {
			myTransform.parent = GameObject.Find ("Terrain02").transform;
		}
	}
}