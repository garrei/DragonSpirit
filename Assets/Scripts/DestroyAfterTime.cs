using UnityEngine;
using System.Collections;

public class DestroyAfterTime : MonoBehaviour {

	public float timeInSeconds;
	
	// Update is called once per frame
	void Update () {
		Destroy (gameObject, timeInSeconds);
	}
}
