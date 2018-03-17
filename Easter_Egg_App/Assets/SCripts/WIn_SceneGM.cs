using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WIn_SceneGM : MonoBehaviour {

	[SerializeField] QRcode QR_Code_Handler;
	[SerializeField] Player_Data_script PD_Scriptt;

	// Use this for initialization
	void Start () 
	{
		PD_Scriptt = GameObject.Find ("Player_Data_Handler").GetComponent<Player_Data_script>();
 		QR_Code_Handler.Assign_Data_To_QRGenerator (PD_Scriptt.Get_Profile_Name());

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
