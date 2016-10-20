using UnityEngine;
using System.Collections;

public class Eggs : MonoBehaviour {

	//0 = Blue, 1 = Green, 2 = Red
	public int myColour;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D (Collider2D other){
		if(other.CompareTag("WeaponDown")){
			if(myColour == 0){
				PlayerAttack.fireRate2 -= 0.3333333f;
				Destroy (gameObject);
			}
			if(myColour == 1){
				PlayerHeads.powerLevel++;
				Destroy (gameObject);
			}
			if(myColour == 2){
				PlayerAttack.fireRate1 -= 0.5f;
				Destroy (gameObject);
			}
		}
	}
}
