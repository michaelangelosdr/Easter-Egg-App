using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Data_Creation : MonoBehaviour {

	[SerializeField] Player_Data_script Player_Data_Handler;
	[SerializeField] PlayerItems_Controller PI_controller;



	public void CreateNew(string givplayername,int givplayerage,string givplayergender)
	{
		Debug.Log ("Creating Data");
		Player_Data_Handler.SaveGameData (givplayername,givplayerage,givplayergender);
		PI_controller.CreatePlayerItem (givplayername,givplayergender);
		PI_controller.Reset_UI ();
	}




}
                                                                                                                                                                                                                                                                                                                                                                      