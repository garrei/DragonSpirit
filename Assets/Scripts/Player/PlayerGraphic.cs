using UnityEngine;
using System.Collections;

public class PlayerGraphic : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		SpriteRenderer sprite1 = GetComponent<SpriteRenderer> ();
		Color sprite1Color = sprite1.color;
		sprite1Color.a = PlayerHealth.myOpacity;
		sprite1.color = sprite1Color;
	
		if (PlayerHealth.mySpriteEnabled == true) {
			sprite1.enabled = true;
		} else {
			sprite1.enabled = false;
		}
	}
}
