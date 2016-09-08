using UnityEngine;
using System.Collections;

public class CameraAspect : MonoBehaviour {

	public Camera letterbox;
	public Camera mainCamera;

		// Update is called once per frame
	void Update () {
		
		/*
		// Maintain the aspect ratio using letterboxing (vertical or horizontal depending screen dimentions)
		if (letterbox.aspect < 0.9f)
		{
			mainCamera.rect = new Rect(0f, (1.0f - letterbox.aspect / 0.9f) / 2, 1.6f, letterbox.aspect / 0.9f);
		}
		else
		{
			mainCamera.rect = new Rect((1.0f - 0.9f / letterbox.aspect) / 2, 0, 0.9f / letterbox.aspect, 1.6f);
		}
		*/
		if (letterbox.aspect < 0.7777777f)
		{
			mainCamera.rect = new Rect(0f, (1f - letterbox.aspect / 0.7777777f) / 2.0f, 1f, letterbox.aspect / 0.7777777f);
		}
		else
		{
			mainCamera.rect = new Rect((1f - 0.7777777f / letterbox.aspect) / 2.0f, 0, 0.7777777f / letterbox.aspect, 1f);
		}


 	}
}
