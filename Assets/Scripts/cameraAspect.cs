using UnityEngine;
using System.Collections;

public class CameraAspect : MonoBehaviour {

	public Camera letterbox;
	public Camera mainCamera;

		// Update is called once per frame
	void Update () {
		
		if (letterbox.aspect < 0.5625f)
		{
			mainCamera.rect = new Rect(0f, (1f - letterbox.aspect / 0.77777777f) / 2.0f, 1f, letterbox.aspect / 0.7777777f);
		}
		else
		{
			mainCamera.rect = new Rect((1f - 0.7777777f / letterbox.aspect) / 2.0f, 0, 0.7777777f / letterbox.aspect, 1f);
		}


 	}
}
