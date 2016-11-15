using UnityEngine;
using System.Collections;

public class CheatScript : MonoBehaviour {
	bool timeIsFast = false;

	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown(KeyCode.F1))
		{
			if (PlayerController.colliderIsOn == true) 
			{
				PlayerController.colliderIsOn = false;
			} 
			else if (PlayerController.colliderIsOn == false) 
			{
				PlayerController.colliderIsOn = true;
			}
		}

		if (Input.GetKeyDown(KeyCode.F2))
			{
			if (Application.loadedLevel == 2)
			{
				Application.LoadLevel (8);
			}
			else if (Application.loadedLevel == 8)
			{
				Application.LoadLevel (2);
			}

			}






	}
}
