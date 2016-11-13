using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AudioController : MonoBehaviour {

	public AudioSource audioSource;
	public AudioClip menuMusic;
	public AudioClip level01Music;
	public AudioClip level02Music;
	public AudioClip mouseHoverButton;
	public AudioClip fire1;
	public AudioClip fire2;
	public AudioClip brokenHS;
	public AudioClip monsterGroan1;
	public AudioClip monsterGroan2;
	public AudioClip monsterGroan3;
	public AudioClip monsterGroan4;
	public AudioClip playerLostHealth;
	public Slider volumeSlider;
	public static float volume;
	private int thePlayersHealth = 3;
	private int thePlayersLives = 3;

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
		audioSource.volume = volume;
		if (Application.loadedLevel == 1) 
		{
			volume = volumeSlider.value;
		}

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

		if (PlayerHealth.lives < thePlayersLives) 
		{
			thePlayersLives = PlayerHealth.lives;
			thePlayersHealth = 3;
		}
		if (PlayerHealth.health < thePlayersHealth) 
		{
			audioSource.PlayOneShot (playerLostHealth);
			thePlayersHealth = PlayerHealth.health;
		}

		//Plays Grunt sounds when the bosses health gets taken down to these values
		if (BossHealth.health == 500 && BossHealth.bossOnScreen == true) 
		{
			audioSource.PlayOneShot (monsterGroan1, 0.50f);
		}
		if (BossHealth.health == 450 || BossHealth.health == 400 || BossHealth.health == 350) 
		{
			audioSource.PlayOneShot (monsterGroan2, 0.50f);
		}
		if (BossHealth.health == 300 || BossHealth.health == 250 || BossHealth.health == 200) 
		{
			audioSource.PlayOneShot (monsterGroan3, 0.50f);
		}
		if (BossHealth.health == 100 || BossHealth.health == 50 || BossHealth.health == 0) 
		{
			audioSource.PlayOneShot (monsterGroan4, 0.50f);
		}
		if (UIManager.playHighScoreBrokenSound == true) 
		{
			audioSource.PlayOneShot (brokenHS);
			UIManager.playHighScoreBrokenSound = false;
		}
	}
}
