using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class soundManager : MonoBehaviour
{

	public AudioSource InitMusic;

	public AudioSource ambientSound;
	public AudioSource BattleSound;
	public AudioSource Lobby;

	public AudioSource JumpPlayer;

	public AudioSource SpeellOne;
	public AudioSource SpeellTwo;



	public float LowPitchRange = .95f;
	public float HighPitchRange = 1.05f;

	public static soundManager Instance = null;
	
	private void Awake()
	{
		if (Instance == null)
		{
			Instance = this;
		}
	
		else if (Instance != this)
		{
			Destroy(gameObject);
		}
	
		DontDestroyOnLoad (gameObject);
	}
	// Play a single clip through the sound effects source.
	public void Play(int audio)
	{
		if (audio==1)Lobby.Play();
		if (audio==2)JumpPlayer.Play();
		if (audio==3)SpeellOne.Play();
		if (audio==4)SpeellTwo.Play();
		if (audio==5)InitMusic.Play();
		if (audio==6)BattleSound.Play();
	}
	// Play a single clip through the music source.
	public void PlayMusic(AudioClip clip)
	{
		ambientSound.clip = clip;
		ambientSound.Play();
	}
	public void BossFigth()
	{
		ambientSound.Stop();
		BattleSound.Play();
	}
	public void backToStart()
	{
		BattleSound.Stop();
	}
	
	
}