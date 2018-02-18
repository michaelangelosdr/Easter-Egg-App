using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Data_script : MonoBehaviour {

	private static Player_Data_script instance = null;

	void Awake()
	{
		instance = this;
	}


	void OnDestroy()
	{
		instance = null;
	}






}
