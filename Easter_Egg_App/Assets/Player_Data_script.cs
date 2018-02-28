using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Data_script : MonoBehaviour {

	private static Player_Data_script instance = null;

	[SerializeField] List<GameObject> Player_Items;
	[SerializeField] GameObject New_button;
	[SerializeField] GameObject Player_Item_Button_Prefab;

	public List<string> Local_PlayerData_Names;

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
			//Destroy (gameObject);

		DontDestroyOnLoad (gameObject);

		CheckData();
	}



	public void CheckData()
	{     
		if (PlayerPrefs.HasKey ("PlayerLocal_data")) {
			Debug.Log ("Player Data Present");

			return;
		}


	}



	public void SaveGameData()
	{

	}


	// To be transfered to PlayerItems_Controller Script
	public void Populate_Menu_Buttons()
	{
		if (Local_PlayerData_Names.Count > 0) {
			New_button.GetComponent<RectTransform> ().anchoredPosition = new Vector2 (-35, 50);


			//Spawning needs to be pooled
			for (int x = 0; x < Local_PlayerData_Names.Count; x++) {
				Player_Items [x].GetComponent<RectTransform> ().anchoredPosition = new Vector2 (x * 35, 50);
			}

		}
	}

	public void Move_Buttons_To_Left()
	{

		if (Player_Items [Local_PlayerData_Names.Count-1].GetComponent<RectTransform> ().anchoredPosition.x == 0) {
			Debug.Log ("Wont MOve");
			return;
		} else {
			for (int x = 0; x < Local_PlayerData_Names.Count; x++) {

				float X = Player_Items [x].GetComponent<RectTransform> ().anchoredPosition.x;
				Player_Items [x].GetComponent<RectTransform> ().anchoredPosition = new Vector2 (X - 35, 50);
			}

			float Xx = New_button.GetComponent<RectTransform> ().anchoredPosition.x;
			New_button.GetComponent<RectTransform> ().anchoredPosition = new Vector2 (Xx - 35, 50);
		}
	}

	public void Move_Buttons_To_Right()
	{

		if (New_button.GetComponent<RectTransform> ().anchoredPosition.x == 0) {
			Debug.Log ("Wont MOve");
			return;
		} else {
			for (int x = 0; x < Local_PlayerData_Names.Count; x++) {

				float X = Player_Items [x].GetComponent<RectTransform> ().anchoredPosition.x;
				Player_Items [x].GetComponent<RectTransform> ().anchoredPosition = new Vector2 (X + 35, 50);
			}

			float Xx = New_button.GetComponent<RectTransform> ().anchoredPosition.x;
			New_button.GetComponent<RectTransform> ().anchoredPosition = new Vector2 (Xx + 35, 50);
		}
	}
}
