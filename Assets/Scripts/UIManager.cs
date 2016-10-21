using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIManager : MonoBehaviour {

	private float highScore;
	public Text scoreText;
	public Text highScoreText;
	public Text areaNumber;
	public static bool playHighScoreBrokenSound = false;

	// Use this for initialization
	void Awake () 
	{
		highScore = PlayerPrefs.GetFloat("hs");
	}

	void Start ()
	{
		areaNumber.text = ("Area: " + SceneManager.levelNumber.ToString ());
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (ScoreCounter.levelScore > highScore) 
		{
			highScore = ScoreCounter.levelScore;
			PlayerPrefs.SetFloat("hs", highScore);
			//playHighScoreBrokenSound = true;
		}

		scoreText.text = Mathf.FloorToInt (ScoreCounter.levelScore).ToString ();	
		highScoreText.text = Mathf.FloorToInt (highScore).ToString();
	}
}
