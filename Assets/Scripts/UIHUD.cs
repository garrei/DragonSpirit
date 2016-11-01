using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIHUD : MonoBehaviour {

	public string uiType = "Fire";
	public int uiNumber = 2;
	public Sprite mySprite;
	public Sprite myTransparentSprite;
	Image myImage;
	RawImage myRawImage;
	// Use this for initialization
	void Start () {
		if(uiType != "Lives"){
		myImage = GetComponent<Image> ();
		}

		if(uiType == "Lives"){
			myRawImage = GetComponent<RawImage> ();
		}
	}
	
	// Update is called once per frame
	void Update () {

		if(uiType == "Fire"){
			if(uiNumber == 2){
				if (PlayerAttack.fireRate1 < 0.11f) {
					myImage.sprite = mySprite;
				} else {
					myImage.sprite = myTransparentSprite;
				}
			}
			if(uiNumber == 3){
				if (PlayerAttack.fireRate1 < 0.06f) {
					myImage.sprite = mySprite;
				} else {
					myImage.sprite = myTransparentSprite;
				}
			}
		}

		if(uiType == "Bomb"){
			if(uiNumber == 2){
				if (PlayerAttack.fireRate2 < 0.7f) {
					myImage.sprite = mySprite;
				} else {
					myImage.sprite = myTransparentSprite;
				}
			}
			if(uiNumber == 3){
				if (PlayerAttack.fireRate2 < 0.4f) {
					myImage.sprite = mySprite;
				} else {
					myImage.sprite = myTransparentSprite;
				}
			}
		}

		if(uiType == "Health"){
			if(uiNumber == 2){
				if (PlayerHealth.health >= 2) {
					myImage.sprite = mySprite;
				} else {
					myImage.sprite = myTransparentSprite;
				}
			}
			if(uiNumber == 3){
				if (PlayerHealth.health == 3) {
					myImage.sprite = mySprite;
				} else {
					myImage.sprite = myTransparentSprite;
				}
			}
		}

		if(uiType == "Lives"){
			if(uiNumber == 2){
				if (PlayerHealth.lives >= 2) {
					myRawImage.enabled = true;
				} else {
					myRawImage.enabled = false;
				}
			}
			if(uiNumber == 3){
				if (PlayerHealth.lives == 3) {
					myRawImage.enabled = true;
				} else {
					myRawImage.enabled = false;
				}
			}
		}


	}
}
