using UnityEngine;
using System.Collections;

public class cameraAspect : MonoBehaviour {

	public Camera letterbox;
	public Camera mainCamera;
	float aspectRatio = 0.7777777f;

		// Update is called once per frame
	void Update () {

		//Aspect ratio is the x side aspect and assumes it's x : 10
		//Screen will always maintain the same aspect ratio
		//A letterbox effect will be used on the top or sides depending on the size of the screen

		if (letterbox.aspect < aspectRatio)
		{
			mainCamera.rect = new Rect(0f, (1f - letterbox.aspect / aspectRatio) / 2.0f, 1f, letterbox.aspect / aspectRatio);
		}
		else
		{
			mainCamera.rect = new Rect((1f - aspectRatio / letterbox.aspect) / 2.0f, 0, aspectRatio / letterbox.aspect, 1f);
		}
 	}
}