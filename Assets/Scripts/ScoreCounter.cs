using UnityEngine;
using System.Collections;

public class ScoreCounter : MonoBehaviour {

	public static float levelScore;
	//private float scoreIncreaseSpeed;

	// Use this for initialization
	void Awake () 
	{
		levelScore = 0f;
	}
}
