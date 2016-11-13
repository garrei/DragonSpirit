using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIManager : MonoBehaviour {

	private float highScore;
	private float level1Score = 0f;
	private float level2Score = 0f;
	public static float runScore;
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
		if (runScore > highScore) 
		{
			highScore = runScore;
			PlayerPrefs.SetFloat("hs", highScore);
			playHighScoreBrokenSound = true;
		}

		runScore += level1Score + level2Score;
		scoreText.text = Mathf.FloorToInt (runScore).ToString ();	
		highScoreText.text = Mathf.FloorToInt (highScore).ToString();
	}
}
