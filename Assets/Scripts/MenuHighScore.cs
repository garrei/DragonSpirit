using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuHighScore : MonoBehaviour 
{
	public Text menuHighScore;

	void Update () 
	{
		menuHighScore.text = Mathf.FloorToInt (PlayerPrefs.GetFloat ("hs")).ToString ();
	}
}
