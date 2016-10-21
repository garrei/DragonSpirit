using UnityEngine;
using System.Collections;

public class AudioController : MonoBehaviour {

	public AudioSource audioSource;
	public AudioClip menuMusic;
	public AudioClip level01Music;
	public AudioClip mouseHoverButton;
	public AudioClip fire1;
	public AudioClip fire2;
	public AudioClip brokenHS;

	//mouse over sound for buttons
	public void hoverButton () 
	{
		audioSource.PlayOneShot (mouseHoverButton);
	}

	void Start()
	{
		
	}

	void Update()
	{
		//fire sounds for both attacks
		if (PlayerAttack.playFire1Sound == true) 
		{
			audioSource.PlayOneShot (fire1);
			PlayerAttack.playFire1Sound = false;
		}
		if (PlayerAttack.playFire2Sound == true) 
		{
			audioSource.PlayOneShot (fire2);
			PlayerAttack.playFire2Sound = false;
		}

		/*if (UIManager.playHighScoreBrokenSound == true) 
		{
			audioSource.PlayOneShot (brokenHS);
			UIManager.playHighScoreBrokenSound = false;
		}*/
	}
}
