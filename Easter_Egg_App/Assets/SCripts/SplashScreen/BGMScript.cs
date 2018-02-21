using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMScript : MonoBehaviour {

	private static BGMScript instance;

	private static BGMScript instanceP{
		get {
			return instance;
		}
	}

	public AudioSource audioSource;

	public AudioClip MenuBGM;



	void Awake()
	{
		if (instance == null) {
			instance = this;
		} else
			Destroy (gameObject);

		DontDestroyOnLoad (gameObject);

		audioSource = GetComponent<AudioSource> ();


		PlayBGMone ();

	}
	public void PlayClip(AudioClip newClip, float volume = 0.75f) {

		if (!enabled)
			return;

		audioSource.volume = volume;
		audioSource.clip = newClip;
		audioSource.Play ();

		Debug.Log ("Playing hehe");
	}

	public void PlayBGMone()
	{
		PlayClip (MenuBGM);
	}


}
