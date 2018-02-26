using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Data_script : MonoBehaviour {

	private static Player_Data_script instance = null;

	[SerializeField] List<GameObject> Player_Items;

	void Awake()
	{
		instance = this;
	}


	void OnDestroy()
	{
		instance = null;
	}


	private void Start()
	{
		if (instance == null) {
			instance = this;
		} else
			Destroy (gameObject);

		DontDestroyOnLoad (gameObject);

		CheckData();
	}



	public void CheckData()
	{

	}
		
	public void SaveGameData()
	{

	}

	public void ReceiveAllData()
	{

	}

	public void Populate_Menu_Buttons()
	{

	}
}
