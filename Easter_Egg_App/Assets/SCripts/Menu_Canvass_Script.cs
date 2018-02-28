using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Menu_Canvass_Script : MonoBehaviour {

	[SerializeField] PlayerItems_Controller PI_cont;
	[SerializeField] GameObject PlayerCreate_Button;


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

	public void ArrowLeft()
	{
		PI_cont.Move_left ();
	}

	public void ArrowRight()
	{
		PI_cont.Move_Right ();


	}

}
