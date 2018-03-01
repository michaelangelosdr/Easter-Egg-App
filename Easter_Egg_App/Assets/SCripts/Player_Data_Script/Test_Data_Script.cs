using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class Test_Data_Script : MonoBehaviour {

	public List<string> Player_Names;
	int SavedACcounts;
	[SerializeField] GameObject Text_Prefab;
	void Start()
	{
		SavedACcounts = 0;
		CheckData ();
	}

	public void CheckData ()
	{
		if (PlayerPrefs.HasKey ("NumberOfAccountsSaved")) {
			SavedACcounts = PlayerPrefs.GetInt ("NumberOfAccountsSaved");
			Debug.Log ("PlayerDataNotEmpty");
			LoadData ();
			return;
		} else {
			Debug.Log ("Player Has No Data");
		}


	}

	public void LoadData()
	{
		for (int x = 1; x < SavedACcounts; x++) {
			Player_Names.Add(PlayerPrefs.GetString("PlayerData_Name"+x.ToString()));
			GameObject Text = Instantiate (Text_Prefab, new Vector3(0,0,0), Quaternion.identity) as GameObject;
		}
	

		foreach (string g in Player_Names) {
			Debug.Log (g);
		}
	}


	public void CreateNewData()
	{
		
		if (!PlayerPrefs.HasKey ("NumberOfAccountsSaved")) {
			SavedACcounts = 1;
			PlayerPrefs.SetInt ("NumberOfAccountsSaved", SavedACcounts);
		}
		string NewPlayerName = "TestPlayer" +SavedACcounts.ToString();
		int NewPlayerAge = SavedACcounts;
		string NewPlayerGender = "TestGender" + SavedACcounts.ToString();
		//string NewPLayerAccount = NewPlayerName + Player_Names.Count + '/' + NewPlayerAge.ToString () + '/' + NewPlayerGender;
		PlayerPrefs.SetString ("PlayerData_Name"+ SavedACcounts.ToString(),NewPlayerName);
		PlayerPrefs.SetInt ("PlayerData_Age" +SavedACcounts.ToString(), NewPlayerAge);
		PlayerPrefs.SetString ("PlayerData_Gender"+SavedACcounts.ToString(), NewPlayerGender);
		SavedACcounts++;
		PlayerPrefs.SetInt ("NumberOfAccountsSaved", SavedACcounts);
		PlayerPrefs.Save ();
		LoadData ();

	}

}
