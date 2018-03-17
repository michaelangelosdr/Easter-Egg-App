using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Data_script : MonoBehaviour {

	private static Player_Data_script instance = null;

	[SerializeField] List<GameObject> Player_Items;
	[SerializeField] GameObject New_button;
	[SerializeField] GameObject Player_Item_Button_Prefab;




	public List<string> Local_PlayerData_Names;
	public List<int> Local_PlayerData_Ages;
	public List<string> Local_PlayerData_Gender;
	int PlayerData_Count;
	public int Profile_Index;



	void Awake()
	{
		//instance = this;
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
		if (PlayerPrefs.HasKey ("Local_PlayerDataCount")) {
			PlayerData_Count = PlayerPrefs.GetInt ("Local_PlayerDataCount");
		
			LoadData ();
			Populate_Menu_Buttons ();
			return;
		} 
		else {
		Debug.Log ("Player Has No Data");
		}

	}

	public void LoadData()
	{
		for (int x = 0; x < PlayerData_Count; x++) {
			Local_PlayerData_Names.Add(PlayerPrefs.GetString("Local_PlayerData_Name"+x.ToString()));
			Local_PlayerData_Ages.Add(PlayerPrefs.GetInt("Local_PlayerData_Age"+x.ToString()));
			Local_PlayerData_Gender.Add(PlayerPrefs.GetString("Local_PlayerData_Gender"+x.ToString()));
		}

		for (int xx = 0; xx < PlayerData_Count; xx++) {
			Player_Item_Button_Prefab.GetComponent<PlayerItems_Controller>().CreatePlayerItem (Local_PlayerData_Names [xx], Local_PlayerData_Gender [xx]);
		}
		 
		for (int xxx = 0; xxx < PlayerData_Count+1; xxx++) {
			Player_Items.Add(  Player_Item_Button_Prefab.transform.GetChild (xxx).gameObject);
			Debug.Log (Player_Items [xxx]);
		}

		Debug.Log ("PlayerData_Count" + PlayerData_Count);
	}


	public void SaveGameData(string playername, int playerage,string playergender)
	{
		PlayerPrefs.SetString ("Local_PlayerData_Name" + PlayerData_Count.ToString (), playername);
		PlayerPrefs.SetString ("Local_PlayerData_Gender" + PlayerData_Count.ToString (), playergender);
		PlayerPrefs.SetInt ("Local_PlayerData_Age" + PlayerData_Count.ToString (), playerage);
		PlayerData_Count++;
		PlayerPrefs.SetInt ("Local_PlayerDataCount",PlayerData_Count);
		PlayerPrefs.Save ();
	}


	// To be transfered to PlayerItems_Controller Script
	public void Populate_Menu_Buttons()
	{
		
		if (PlayerData_Count > 0) {
			Player_Items[0].GetComponent<RectTransform> ().anchoredPosition = new Vector2 (-35, 50);


			//Spawning needs to be pooled
			for (int x = 0; x <Player_Items.Count; x++) {
				Player_Items [x].GetComponent<RectTransform> ().anchoredPosition = new Vector2 (x * 35, 50);

			}
		}
	}

	public void Move_Buttons_To_Left()
	{
		if (Player_Items [Player_Items.Count-1].GetComponent<RectTransform> ().anchoredPosition.x == 0) {
			Debug.Log ("Wont MOve");
			return;
		} else {
			for (int x = 0; x < Player_Items.Count; x++) {
				float X = Player_Items [x].GetComponent<RectTransform> ().anchoredPosition.x;
				Player_Items [x].GetComponent<RectTransform> ().anchoredPosition = new Vector2 (X - 35, 50);
			}				
		}
	}

	public void Move_Buttons_To_Right()
	{
		if (Player_Items[0].GetComponent<RectTransform> ().anchoredPosition.x == 0) {
			Debug.Log ("Wont MOve");
			return;
		} else {
			for (int x = 0; x < Player_Items.Count; x++) {
				float X = Player_Items [x].GetComponent<RectTransform> ().anchoredPosition.x;
				Player_Items [x].GetComponent<RectTransform> ().anchoredPosition = new Vector2 (X + 35, 50);
			}
		}
	}

	// DEBUGGING METHODS
	public void AddtoPlayerItemList()
	{
		Local_PlayerData_Names.Add(PlayerPrefs.GetString("Local_PlayerData_Name"+ (PlayerData_Count-1).ToString()));
		Local_PlayerData_Ages.Add(PlayerPrefs.GetInt("Local_PlayerData_Age"+(PlayerData_Count -1).ToString()));
		Local_PlayerData_Gender.Add(PlayerPrefs.GetString("Local_PlayerData_Gender"+(PlayerData_Count-1).ToString()));

		if (Player_Items.Count == 0) {
			Player_Items.Add (Player_Item_Button_Prefab.transform.GetChild (0).gameObject);
		}
		Player_Items.Add(Player_Item_Button_Prefab.transform.GetChild (Player_Items.Count).gameObject);
		Debug.Log ("PlayerItem Count: " + Player_Items.Count);

	}


	public void Get_Profile_Index()
	{

		for (int index = 0; index < PlayerData_Count+1; index++) {

			if (Player_Items [index].GetComponent<RectTransform> ().anchoredPosition.x == 0) {
				Profile_Index = index-1;
				Debug.Log (Profile_Index + " IS the profile Index");
			}
		}

	}

	public string Get_Profile_Name()
	{
		return Local_PlayerData_Names [Profile_Index];
	}
	public string Get_Profile_Gender()
	{
		return Local_PlayerData_Gender [Profile_Index];
	}
	public int Get_Profile_Age()
	{
		return Local_PlayerData_Ages [Profile_Index];
	}
}
