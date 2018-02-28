using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Data_Creation : MonoBehaviour {

	[SerializeField] Player_Data_script Player_Data_Handler;
	[SerializeField] PlayerItems_Controller PI_controller;



	public void CreateNew()
	{
		Player_Data_Handler.Local_PlayerData_Names.Add ("Test" + Player_Data_Handler.Local_PlayerData_Names.Count);	
		PI_controller.Reset_UI ();
	}




}
