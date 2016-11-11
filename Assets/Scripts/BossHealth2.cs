using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BossHealth2 : MonoBehaviour {

	public static float health = 500;
	float maxHealth = 500;
	float healthPercent;
	public int score = 0;
	public GameObject spawnOnDeath;
	Transform myTransform;
	GameObject myTerrain;
	bool bossOnScreen;
	public GameObject Boss;
	GameObject healthBarBack;
	GameObject healthBarBackground;
	GameObject healthFill;
	Image healthBarBackImage;
	Image healthBarBackgroundImage;
	Image healthFillImage;


	// Update is called once per frame
	void Start (){
		myTransform = transform;
		myTerrain = GameObject.Find ("Terrain");
		healthBarBackground = GameObject.Find ("HeathbarBackground");
		healthBarBack = GameObject.Find ("HeathbarBack");
		healthFill = GameObject.Find ("HeathbarFill");
		healthFillImage = healthFill.GetComponent<Image>();
		healthBarBackImage = healthBarBack.GetComponent<Image>();
		healthBarBackgroundImage = healthBarBackground.GetComponent<Image>();
		healthFillImage.enabled = !healthFillImage.enabled;
		healthBarBackImage.enabled = !healthBarBackImage.enabled;
		healthBarBackgroundImage.enabled = !healthBarBackgroundImage.enabled;
	}

	void Update () {


		healthPercent = health / maxHealth;
//		Debug.Log (healthPercent);
		healthFillImage.fillAmount = healthPercent;

		if ((health < 1 && myTransform.parent == null) || (health < 1 && CompareTag("Credits"))){
			OnDeath ();
			Destroy (gameObject);
		} else
			if (health < 1 && myTransform.parent.parent != null){
				OnDeath ();
				if(gameObject.transform.parent.parent.gameObject != myTerrain){
				Destroy (gameObject.transform.parent.parent.gameObject);
				}
				if(gameObject.transform.parent.parent.gameObject == myTerrain){
					Destroy (gameObject.transform.parent.gameObject);
				}
			} else
				if (health < 1 && myTransform.parent != null){
					OnDeath ();
					if(gameObject.transform.parent.gameObject != myTerrain){
					Destroy (gameObject.transform.parent.gameObject);
					}
					if(gameObject.transform.parent.gameObject == myTerrain){
						Destroy (gameObject);
					}
				}
	}

	void OnDeath (){
		ScoreCounter.levelScore += score;
		Instantiate (spawnOnDeath, myTransform.position,Quaternion.identity);
	}

	//This checks whether the bullet should hit the enemy or not depending on it being airbourne or not
	void OnTriggerEnter2D (Collider2D other){
		if((other.CompareTag("WeaponForward") && gameObject.CompareTag("Airborne")) || (other.CompareTag("WeaponForward") && gameObject.CompareTag("Credits"))){
			Destroy (other.gameObject);
			health--;
		}
		if(other.CompareTag("WeaponDown") && gameObject.CompareTag("Grounded")){
			Destroy (other.gameObject);
			health--;
		}
	}
}
