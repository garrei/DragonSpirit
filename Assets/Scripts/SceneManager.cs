﻿using UnityEngine;
using System.Collections;

public class SceneManager : MonoBehaviour {

	public static int levelNumber;
	public bool uiLoaded;

	// Use this for initialization
	void Start () 
	{
		//Level 1
		if (Application.loadedLevel == 2 && uiLoaded == false) 
		{
			LoadUI ();
			Buttons.pauseMenu.SetActive (false);
			levelNumber = 1;
		}
	}
	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.Escape)) 
		{
			if (Buttons.isPaused == false) {
				Buttons.pauseMenu.SetActive (true);
				Time.timeScale = 0;
				Buttons.isPaused = true;
				Debug.Log("Memes On");
			} 
			else 
			{
				Buttons.pauseMenu.SetActive (false);
				Time.timeScale = 1;
				Buttons.isPaused = false;
				Debug.Log("Memes Off");
			}
		}
		if (BossHealth.health < 1) 
		{
			Application.LoadLevel (6);
			BossHealth.health = 500;
		}
	}

	void LoadUI ()
	{
		//Loads the UI into the game scene
		//this int should be the int of the UI scene in the build settings.
		Application.LoadLevelAdditive (3);
		uiLoaded = true;
	}
}
