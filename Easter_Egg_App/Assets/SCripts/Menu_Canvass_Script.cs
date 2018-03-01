using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Menu_Canvass_Script : MonoBehaviour {

	[SerializeField] PlayerItems_Controller PI_cont;
	[SerializeField] GameObject PlayerCreate_Button;
	[SerializeField] Player_Data_Creation PD_Create;






	// Player Creation Objects
	[SerializeField] GameObject PlayerCreation_Modal;
	[SerializeField] GameObject NameInputField;
	[SerializeField] GameObject AgeInputField;
	[SerializeField] GameObject GenderInput;
	[SerializeField] GameObject Girl_Button;
	[SerializeField] GameObject Boy_Button;


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

	public void ShowCreationMenu()
	{
		if(!PlayerCreation_Modal.activeInHierarchy)
		PlayerCreation_Modal.SetActive (true);
	}

	public void OnCreateClicked()
	{
		string Player_Name = NameInputField.GetComponent<InputField> ().text;
		int Player_Age = int.Parse(AgeInputField.GetComponent<InputField> ().text);
		string Player_Gender = GenderInput.GetComponent<Text> ().text;
		PD_Create.CreateNew (Player_Name,Player_Age,Player_Gender);
	
	}

	public void SetGender(GameObject Button)
	{
		if (Button.name == "Boy_Button") {
			GenderInput.GetComponent<Text> ().text = "Boy";
		}
		if (Button.name == "Girl_Button") {
			GenderInput.GetComponent<Text> ().text = "Girl";
		}

	}

}
