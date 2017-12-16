using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasController_Script : MonoBehaviour {

	[SerializeField] GameObject UI_InventoryPanel;
	[SerializeField] Text UI_Text_EggCollected;
	[SerializeField] Game_Manager_Script GM_Script;
	[SerializeField] GameObject  Canvass_Inventory_Panel;



	//Canvass Objects
	[SerializeField] List<GameObject> Canvass_EggObjects;

	// Use this for initialization
	public void Start () {
		GM_Script.NUM_EggsCollected = 0;
		UI_Text_EggCollected.text = "O";
		//Show_Canvass_Eggs ();
		StartCoroutine (DistributeEggs_CInventory());
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

	IEnumerator DistributeEggs_CInventory()
	{
		if (Canvass_Inventory_Panel.activeInHierarchy) {

			foreach (GameObject egg_UI in Canvass_EggObjects) {


				GetChildGameObject (egg_UI, "Egg_Open").GetComponent<Image>().enabled = false;
					GetChildGameObject (egg_UI, "Egg_Missing").GetComponent<Image>().enabled = true;
				}				
		}

		return null;
	}

	public void Show_Canvass_Eggs()
	{
		int EggsFound;
		EggsFound = 0;
		foreach (GameObject egg_UI in Canvass_EggObjects) {
			
			if (EggsFound < GM_Script.NUM_EggsCollected) {
				GetChildGameObject (egg_UI, "Egg_Open").GetComponent<Image>().enabled = true;
				GetChildGameObject (egg_UI, "Egg_Missing").GetComponent<Image>().enabled = false;
			}
			EggsFound++;

			Debug.Log (EggsFound + " MAX EH " + GM_Script.NUM_EggsCollected);
		}
	}

	public GameObject GetChildGameObject(GameObject fromGameObject, string Name)
	{
		Transform[] ts = fromGameObject.transform.GetComponentsInChildren<Transform> ();
		foreach (Transform t in ts) {
			if(t.gameObject.name == Name)
			{
				return t.gameObject;
			}
		}
		return null;
	}
}
