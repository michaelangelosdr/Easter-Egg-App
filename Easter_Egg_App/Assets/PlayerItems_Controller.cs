using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerItems_Controller : MonoBehaviour {

	[SerializeField] Player_Data_script Player_Data;
	[SerializeField] GameObject Button_scroll;
	[SerializeField] GameObject PlayerItem_Button_Prefab;
	[SerializeField] GameObject thisobject;



	public void Reset_UI()
	{
		List<GameObject> Player_Item_Objects = new List<GameObject>();
		foreach (Transform t in transform) {
			Player_Item_Objects.Add (t.gameObject);
		}

		foreach (GameObject g in Player_Item_Objects) {
			g.GetComponent<RectTransform> ().anchoredPosition = new Vector2 (999, 999);
		}


		Player_Data.AddtoPlayerItemList ();
		Player_Data.Populate_Menu_Buttons ();
	}


	public void CreatePlayerItem(string UIName,string UIGender)
	{
		
		GameObject Playeritem = Instantiate (PlayerItem_Button_Prefab, new Vector3(0,0,0), Quaternion.identity) as GameObject;
		Playeritem.name = "PlayerItemButton";


		if (UIGender == "Boy") {
			//Girl_button
			Playeritem.transform.GetChild (1).gameObject.SetActive (true);
			//Boy_Button
			Playeritem.transform.GetChild (0).gameObject.SetActive (false);
			//WON_text
			Playeritem.transform.GetChild (2).gameObject.SetActive (false);
		} 
		if (UIGender == "Girl") {
			//Girl_button
			Playeritem.transform.GetChild (0).gameObject.SetActive (true);
			//Boy_Button
			Playeritem.transform.GetChild (1).gameObject.SetActive (false);
			//WON_text
			Playeritem.transform.GetChild (2).gameObject.SetActive (false);
		}


		Playeritem.transform.GetChild (3).GetComponent<Text> ().text = UIName;



		Playeritem.transform.SetParent (transform);
		//Reset_UI ();

	}


	public void Move_left()
	{
		Player_Data.Move_Buttons_To_Left ();
	}

	public void Move_Right()
	{
		Player_Data.Move_Buttons_To_Right ();
	}


}
