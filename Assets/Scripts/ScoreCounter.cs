using UnityEngine;
using System.Collections;

public class ScoreCounter : MonoBehaviour {

	public static float levelScore;
	private float scoreIncreaseSpeed;

	// Use this for initialization
	void Awake () 
	{
		levelScore = 0f;
		scoreIncreaseSpeed = 40f;
	}
	
	// Update is called once per frame
	void Update () 
	{
		levelScore = levelScore += scoreIncreaseSpeed * Time.deltaTime;
		Debug.Log (levelScore.ToString ());
	}
}
