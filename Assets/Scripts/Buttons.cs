using UnityEngine;
using System.Collections;

public class Buttons : MonoBehaviour {
	public static GameObject pauseMenu;
	public static GameObject helpMenu;
	public static bool isPaused;
	public static bool hardMode = true;

	void Start ()
	{
		pauseMenu = GameObject.FindGameObjectWithTag ("PauseMenu");
		helpMenu = GameObject.FindGameObjectWithTag ("HelpMenu");
	}

	//BUTTON METHODS*******************************************************************

	public void QuitGame () 
	{
		Application.Quit();
	}
	public void ReturnToMenu ()
	{
		if (Application.loadedLevel == 2) 
		{
			pauseMenu.SetActive (false);
			isPaused = false;
		}
		Application.LoadLevel (1);
		Time.timeScale = 1;
	}
	public void StartGame () 
	{
		Application.LoadLevel (2);
	}
	public void HelpMenu () 
	{
		Application.LoadLevel (7);
	}
	public void ResetHS () 
	{
		PlayerPrefs.SetFloat ("hs", 0f);
	}
	public void ResumeGame () 
	{
		if (pauseMenu.activeInHierarchy == true) 
		{
			pauseMenu.SetActive (false);
			Time.timeScale = 1;
			isPaused = false;
		}
	}
	public void LoadCredits ()
	{
		Application.LoadLevel (5);
	}

	public void HardModeToggle()
	{
		hardMode = !hardMode;
		Debug.Log (hardMode);
	}

	//**********************************************************************************
}
