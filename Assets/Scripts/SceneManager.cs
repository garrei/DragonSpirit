using UnityEngine;
using System.Collections;

public class SceneManager : MonoBehaviour {

	public static int levelNumber;
	private bool UIloaded = false;
	private bool isPaused = false;
	public GameObject pauseMenu;

	// Use this for initialization
	void Start () 
	{
		//IMPORTANT!!!! - LOADED LEVEL MUST MATCH SCENE NUMBER IN BUILD SETTINGS!!!
		//Level 1
		if (Application.loadedLevel == 1 && UIloaded == false) 
		{
			//Loads the UI into the game scene
			//this int should be the int of the UI scene in the build settings. This will increase with every level added so the ints match the level numbers of the game.
			Application.LoadLevelAdditive (2);
			UIloaded = true;
			levelNumber = 1;
		}
	}
	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.Escape)) 
		{
			if (isPaused == false) {
				pauseMenu.SetActive (true);
				Time.timeScale = 0;
				isPaused = true;
				Debug.Log ("Memes On");
			} 
			else 
			{
				pauseMenu.SetActive (false);
				isPaused = false;
				Time.timeScale = 1;
				Debug.Log("Memes Off");
			}
		}
	}
		

	//BUTTON METHODS*******************************************************************

	public void QuitGame () 
	{
		Application.Quit();
	}
	public void ReturnToMenu ()
	{
		Application.LoadLevel (0);
		Time.timeScale = 1;
	}
	public void StartGame () 
	{
		Application.LoadLevel (1);
	}
	public void ResetHS () 
	{
		PlayerPrefs.SetFloat ("hs", 0f);
	}
	public void ResumeGame () 
	{
		pauseMenu.SetActive (false);
		Time.timeScale = 1;
		isPaused = false;
	}

	//**********************************************************************************
}
