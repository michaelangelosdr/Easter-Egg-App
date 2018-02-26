using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Menu_Canvass_Script : MonoBehaviour {



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}



	public void ButtonFunctionality(GameObject Button)
	{
		if (Button.name == "start_but") {
			//Load Game scene
			SceneManager.LoadScene (2);
		}
		if (Button.name == "return") {
			SceneManager.LoadScene (0);
		}


	}

}
