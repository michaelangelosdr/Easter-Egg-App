using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashScreen_Script : MonoBehaviour {



	void Awake()
	{

	}
		


	public void LoadScenes()
	{
		Debug.Log ("Change now");
		SceneManager.LoadScene (1);
	}
}
