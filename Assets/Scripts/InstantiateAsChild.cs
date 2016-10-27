using UnityEngine;
using System.Collections;

public class InstantiateAsChild : MonoBehaviour {

	Transform myTransform;

	// Use this for initialization
	void Start () {
		myTransform = transform;
		myTransform.parent = GameObject.Find ("Terrain").transform;
	}
}