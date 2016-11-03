using UnityEngine;
using System.Collections;

public class OrbMove : MonoBehaviour {

	float speedVertical = 2f;
	Transform myTransform;
	//0 = Blue, 1 = Green, 2 = Red
	public int myColour = 0;

	// Use this for initialization
	void Start () 
	{
		myTransform = transform;
	}
	
	// Update is called once per frame
	void Update () 
	{
		myTransform.Translate (Vector3.down * Time.deltaTime * speedVertical);
	}

	void OnTriggerEnter2D (Collider2D other){
		if(other.CompareTag("Player")){
			if(myColour == 0){
				PlayerAttack.fireRate2 -= 0.35f;
			}
			if(myColour == 1){
				PlayerHeads.powerLevel++;
			}
			if(myColour == 2){
				PlayerAttack.fireRate1 -= 0.05f;
		}
			Destroy (gameObject);
	}
  }
}