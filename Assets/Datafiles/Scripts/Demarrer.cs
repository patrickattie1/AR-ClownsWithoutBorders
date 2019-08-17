using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Demarrer : MonoBehaviour 
{
	public static bool readyToLoadNextScene = false;

	// Use this for initialization
	void Start () 
	{
		
	}

	public void ChangeScene()
	{
		readyToLoadNextScene = true;
	}

	public void Arreter()
	{
		readyToLoadNextScene = false;
		Application.Quit ();
	}
		
}
