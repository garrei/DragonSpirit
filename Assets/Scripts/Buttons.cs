using UnityEngine;
using System.Collections;

public class Buttons : MonoBehaviour {

	public static GameObject pauseMenu;
	public static bool isPaused;

	void Start ()
	{
		pauseMenu = GameObject.FindGameObjectWithTag ("PauseMenu");
	}

	//BUTTON METHODS*******************************************************************

	public void QuitGame () 
	{
		Application.Quit();
	}
	public void ReturnToMenu ()
	{
		Application.LoadLevel (1);
		Time.timeScale = 1;
	}
	public void StartGame () 
	{
		Application.LoadLevel (2);
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
	public void LoadCredits ()
	{
		Application.LoadLevel (5);
	}

	//**********************************************************************************
}
