using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItems_Controller : MonoBehaviour {

	[SerializeField] Player_Data_script Player_Data;
	[SerializeField] GameObject Button_scroll;



	public void Reset_UI()
	{
		List<GameObject> Player_Item_Objects = new List<GameObject>();
		foreach (Transform t in transform) {
			Player_Item_Objects.Add (t.gameObject);
		}

		foreach (GameObject g in Player_Item_Objects) {
			g.GetComponent<RectTransform> ().anchoredPosition = new Vector2 (999, 999);
		}



		Player_Data.Populate_Menu_Buttons ();
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
