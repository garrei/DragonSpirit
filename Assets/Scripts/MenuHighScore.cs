using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuHighScore : MonoBehaviour 
{
	public Text menuHighScore;
	public Text currentRunScore;

	void Start ()
	{
		currentRunScore.text = Mathf.FloorToInt (ScoreCounter.levelScore).ToString ();
	}

	void Update () 
	{
		menuHighScore.text = Mathf.FloorToInt (PlayerPrefs.GetFloat ("hs")).ToString ();
	}
}
