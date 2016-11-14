using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour {

	public GameObject equippedWeaponForward, equippedWeaponDown;
	Transform myTransform;
	public static float fireRate1 = 0.15f;
	public static float fireRate2 = 1f;
	public static bool playFire1Sound = false;
	public static bool playFire2Sound = false;
	float nextFire = 0;
	public static bool playerAttackIsBossDead = false;

	// Use this for initialization
	void Start () {
		myTransform = transform;
		playerAttackIsBossDead = false;

		//Only want to reset powerups on level 1
		if(Application.loadedLevel == 2){
			fireRate1 = 0.15f;
			fireRate2 = 1f;
		}
	}
	
	// Update is called once per frame
	void Update () {

		if(fireRate1 < 0.01f){
			fireRate1 = 0.05f;
		}

		if(fireRate2 < 0.2f){
			fireRate2 = 0.3f;
		}

		//fireRate1 and fireRate 2 are used to determine the rate of fire, duh
		//Uses Time.time to be sure it is as consistent as possible
		if(Input.GetButton("Fire1") && Time.time > nextFire && Time.time > PlayerHealth.deathNextCool && Buttons.isPaused == false && playerAttackIsBossDead == false){
			nextFire = Time.time + fireRate1;
			Instantiate (equippedWeaponForward, myTransform.position, Quaternion.identity);
			playFire1Sound = true;
		}
		if(Input.GetButton("Fire2") && Time.time > nextFire && !Input.GetButton("Fire1") && Time.time > PlayerHealth.deathNextCool && Buttons.isPaused == false && playerAttackIsBossDead == false){
			nextFire = Time.time + fireRate2;
			Instantiate (equippedWeaponDown, myTransform.position, Quaternion.identity);
			playFire2Sound = true;
		}
	}
}
