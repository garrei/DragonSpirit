using UnityEngine;
using System.Collections;

public class PlayerHeads : MonoBehaviour {

	GameObject oneHead;
	GameObject twoHead;
	GameObject threeHead;
	public static int powerLevel = 0;

	// Use this for initialization
	void Start () {
		
		//Only want to reset powerups on level 1
		if(Application.loadedLevel == 2){
		powerLevel = 0;
		}
		oneHead = GameObject.Find ("PlayerGraphic1");
		twoHead = GameObject.Find ("PlayerGraphic2");
		threeHead = GameObject.Find ("PlayerGraphic3");
	
	}
	
	// Update is called once per frame
	void Update () {

		//Don't want this nerd to be greater than 2
		if(powerLevel > 2){
			powerLevel = 2;
		}

		//This uses the powerLevel to change the amount of heads
		if(powerLevel == 0){
			oneHead.SetActive (true);
			twoHead.SetActive (false);
			threeHead.SetActive (false);
		}

		if(powerLevel == 1){
			twoHead.SetActive (true);
			oneHead.SetActive (false);
			threeHead.SetActive (false);
		}
		if(powerLevel == 2){
			threeHead.SetActive (true);
			twoHead.SetActive (false);
			oneHead.SetActive (false);
		}

		//These make sure that only one body is active at once (NOT NEEDED)
		/*
		if(oneHead.activeSelf == true){
			twoHead.SetActive (false);
			threeHead.SetActive (false);
		}

		if(twoHead.activeSelf == true){
			oneHead.SetActive (false);
			threeHead.SetActive (false);
		}

		if(threeHead.activeSelf == true){
			twoHead.SetActive (false);
			oneHead.SetActive (false);
		}
		*/
	}
}
