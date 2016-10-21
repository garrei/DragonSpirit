using UnityEngine;
using System.Collections;

public class Eggs1 : MonoBehaviour {

	//0 = Blue, 1 = Green, 2 = Red
	public int myColour;
	public GameObject BlueOrb;
	public GameObject RedOrb;
	public GameObject YellowOrb;
	public GameObject GreenOrb;
	public GameObject PurpleOrb;
	Animator anim;


	// Use this for initialization
	void Start () {
		anim = GetComponent <Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D (Collider2D other){
		if(other.CompareTag("WeaponDown")){
			if(myColour == 0){
				//PlayerAttack.fireRate2 -= 0.3333333f;
				Instantiate(BlueOrb, transform.position, Quaternion.identity);
			}
			if(myColour == 1){
				//PlayerHeads.powerLevel++;
				Instantiate(GreenOrb, transform.position, Quaternion.identity);
			}
			if(myColour == 2){
				//PlayerAttack.fireRate1 -= 0.05f;
				Instantiate(RedOrb, transform.position, Quaternion.identity);
			}

			//if (!anim.isPlaying) 
			//{
			//	Destroy (gameObject);
			//}
		}
	}
}
