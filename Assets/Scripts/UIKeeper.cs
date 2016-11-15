using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIKeeper : MonoBehaviour {
	public Toggle DifficultyToggle;
	public Slider VolumeSlider;

	// Use this for initialization
	void Start () 
	{
		DifficultyToggle.isOn = Buttons.hardMode;
		VolumeSlider.value = AudioController.volume;


	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
