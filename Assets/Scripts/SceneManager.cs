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
			Application.LoadLevelAdditive (0);

			levelNumber = 1;
		}
		//Level 2

	}
	
	// Update is called once per frame
	void Update () 
	{

	}
}
