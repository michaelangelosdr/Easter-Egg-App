using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasController_Script : MonoBehaviour {

	[SerializeField] GameObject UI_InventoryPanel;
	[SerializeField] Text UI_Text_EggCollected;
	[SerializeField] Game_Manager_Script GM_Script;

	// Use this for initialization
	public void Start () {
		GM_Script.NUM_EggsCollected = 0;
		UI_Text_EggCollected.text = "O";
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Change_ScoreText()
	{
		UI_Text_EggCollected.text = GM_Script.NUM_EggsCollected.ToString ();
	}

	public void Canvas_ShowInventory(bool Activate)
	{
		UI_InventoryPanel.SetActive (Activate);
	}

}
