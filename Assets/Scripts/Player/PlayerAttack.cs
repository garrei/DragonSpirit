using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour {

	public GameObject equippedWeaponForward, equippedWeaponDown;
	Transform myTransform;
	float fireRate1 = 0.15f;
	float fireRate2 = 1f;
	float nextFire = 0;

	// Use this for initialization
	void Start () {
		myTransform = transform;
	}
	
	// Update is called once per frame
	void Update () {

		//fireRate1 and fireRate 2 are used to determine the rate of fire, duh
		//Uses Time.time to be sure it is as consistent as possible
		if(Input.GetButton("Fire1") && Time.time > nextFire){
			nextFire = Time.time + fireRate1;
			Instantiate (equippedWeaponForward, myTransform.position, Quaternion.identity);
		}
		if(Input.GetButton("Fire2") && Time.time > nextFire && !Input.GetButton("Fire1")){
			nextFire = Time.time + fireRate2;
			Instantiate (equippedWeaponDown, myTransform.position, Quaternion.identity);
		}
	}
}
