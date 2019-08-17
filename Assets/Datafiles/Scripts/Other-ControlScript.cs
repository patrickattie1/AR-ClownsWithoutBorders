using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlScript : MonoBehaviour {

	AudioSource audio;
	public AudioClip[] clips;

	// Use this for initialization
	void Start () 
	{
		audio = GetComponent<AudioSource> ();
		StartCoroutine (IntroJingle ());
	}

	private void PlaySound(int sound)
	{
		audio.clip = clips [sound];
		audio.Play ();
	}

	private IEnumerator IntroJingle()
	{
		yield return new WaitForSeconds (3f);
		PlaySound (0);
		StartCoroutine (Quack ());
	}

	private IEnumerator Quack()
	{
		yield return new WaitForSeconds (1.8f);
		PlaySound (1);
		StartCoroutine (Dog ());
	}

	private IEnumerator Dog()
	{
		yield return new WaitForSeconds (0.5f);
		PlaySound (2);
		StartCoroutine (GunShots ());
	}

	private IEnumerator GunShots()
	{
		yield return new WaitForSeconds (0.4f);
		PlaySound (3);
	}

	public void ChangeScene()
	{
		SceneManager.LoadScene ("MainScene");
	}
		
}
