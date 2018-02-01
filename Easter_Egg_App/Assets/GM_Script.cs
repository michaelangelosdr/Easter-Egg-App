using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class GM_Script : MonoBehaviour {

	[SerializeField] Transform TestTarget_list;
	[SerializeField]  Canvass_Controller C_controller;

	private List<Transform> AllTargets;
	public int Number_Of_Targets;
	private int[] Image_Targets;


	public static int Object_Collected_Count;




	private Transform[] targets;


	//private List<GameObject> Targets = GetComponentInChildren<Transform>();



	// Use this for initialization
	void Start () {


		Object_Collected_Count = 0;

		Image_Targets = new int[Number_Of_Targets];
		
		AllTargets = new List<Transform> ();

		if (Object_Collected_Count <= 0) {
			for (int x = 0; x < 5; x++) {	
				C_controller.Object_Visibility_Off (x);
			}
		}


		foreach (Transform target in TestTarget_list) {
			AllTargets.Add (target);
		}

	

		for (int x = 0; x < Number_Of_Targets; x++) {
			Image_Targets [x] = Random.Range (0, AllTargets.Count);	
		}

	
		for (int x = 0; x < Number_Of_Targets; x++) {

			for (int y = x + 1; y < Number_Of_Targets ; y++) {

				if(Image_Targets[x] == Image_Targets[y])
				{
					Debug.Log (Image_Targets [x] + "AND" + Image_Targets[y] );
				}

				while (Image_Targets [x] == Image_Targets [y]) {
					Image_Targets [x] = Random.Range (0, AllTargets.Count);	
				}



			}


		}


		
		

		StartCoroutine (LoadEggs ());



	
	
	}

	public void SpawnEggsOnTargets()
	{

	}

	// Update is called once per frame
	void Update () {

	}
		

	IEnumerator LoadEggs()
	{




		for (int x = 0; x < Number_Of_Targets; x++) {
			
			BaseObject G; 
			G =	ObjectFactory.TryCreateObject (Egg_Type.BASIC);
			G.name = "BasicEgg";
			G.transform.SetParent (AllTargets[Image_Targets[x]].transform);
			G.transform.localPosition = new Vector3 (0, 0.25f, -0.25f);

			if (x == Number_Of_Targets) {
				G.name = "Last";
				G.GetComponent<MeshRenderer> ().enabled = false;
				G.GetComponent<MeshCollider> ().enabled = false;
			}

		}
		
		yield return new WaitForEndOfFrame ();

	}


	public void Object_Collected_Successfully()
	{
		C_controller.Object_Visibility_On (Object_Collected_Count);	
		Debug.Log ("Egg_Collected");
		Object_Collected_Count++;
		C_controller.Object_Count_Change ();
	}


	// ======================= Canvas Manager ============================


}
