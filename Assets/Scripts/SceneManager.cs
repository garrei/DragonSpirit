using UnityEngine;
using System.Collections;

public class SceneManager : MonoBehaviour {

	public static int levelNumber;

	// Use this for initialization
	void Start () 
	{
		//IMPORTANT!!!! - LOADED LEVEL MUST MATCH SCENE NUMBER IN BUILD SETTINGS!!!
		//Level 1
		if (Application.loadedLevel == 1) 
		{
			//Loads the UI into the game scene
			LoadUI ();

			levelNumber = 1;
		}
		//Level 2

	}

	void LoadUI () 
	{
		//this int should be the int of the UI scene in the build settings. This will increase with every level added so the ints match the level numbers of the game.
		Application.LoadLevelAdditive (2);
	}
	public void PauseGame () 
	{
		Time.timeScale = 0;
	}

	//BUTTON METHODS*******************************************************************

	public void QuitGame () 
	{
		Application.Quit();
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
		Time.timeScale = 1;
	}

	//**********************************************************************************
}
