using UnityEngine;
using System.Collections;

public class SoundBox : MonoBehaviour {

//	static public AudioClip		sound;
	static public AudioClip		gameOver;
	static public AudioClip		death;
	static public AudioClip		win;
	static public AudioSource	source;
	
	public AudioClip		AgameOver;
	public AudioClip		Adeath;
	public AudioClip		Awin;

	void Awake()
	{
		SoundBox.gameOver = AgameOver;
		SoundBox.death = Adeath;
		SoundBox.win = Awin;
		SoundBox.source = GetComponent<AudioSource>();
		SoundBox.source.Play();
	}

	static public void		playWin()
	{
		SoundBox.source.PlayOneShot(SoundBox.win);
	}

	static public void		playGameOver()
	{
		SoundBox.source.PlayOneShot(SoundBox.gameOver);
	}
	
	static public void		playDeath()
	{
		SoundBox.source.PlayOneShot(SoundBox.death);
	}
}
