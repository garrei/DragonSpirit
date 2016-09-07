using UnityEngine;
using System.Collections;

public class cameraAspect : MonoBehaviour {

	public Camera letterbox;
	public Camera MainCamera;

	// Update is called once per frame
	void Update () {
		
		// Maintain the 9:16 aspectratio using letterboxing (vertical or horisontal depending screen dimensions)
		if (letterbox.aspect < 0.9f)
		{
			MainCamera.rect = new Rect(0f, (1.0f - letterbox.aspect / 0.9f) / 2.0f, 1.6f, letterbox.aspect / 0.9f);
		}
		else
		{
			MainCamera.rect = new Rect((1.0f - 0.9f / letterbox.aspect) / 2.0f, 0, 0.9f / letterbox.aspect, 1.6f);
		}
 	}
}
