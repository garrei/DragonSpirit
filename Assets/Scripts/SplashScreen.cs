using UnityEngine;
using System.Collections;

public class SplashScreen : MonoBehaviour {
	float screenTime = 0;

	void Update () 
	{
		screenTime = screenTime + Time.deltaTime;

		if (screenTime >= 5) 
		{
			Application.LoadLevel (0);
		}

		if (Input.GetKeyDown (KeyCode.Space)) 
		{
			Application.LoadLevel (0);
		} 

		if (Input.GetButton("Fire1")) 
		{
			Application.LoadLevel (0);
		} 
	}
}
