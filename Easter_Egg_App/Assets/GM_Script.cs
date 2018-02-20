using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class GM_Script : MonoBehaviour {

	[SerializeField] Transform TestTarget_list;
	[SerializeField]  Canvass_Controller C_controller;


	//List
	private List<int> UnUsedIndexes;

	private List<Transform> AllTargets;
	public int Number_Of_Targets;
	private int[] Image_Targets;


	public static int Object_Collected_Count;




	private Transform[] targets;


	//private List<GameObject> Targets = GetComponentInChildren<Transform>();



	// Use this for initialization
	void Start () {


		Object_Collected_Count = 0;

		UnUsedIndexes = new List<int> ();

		Image_Targets = new int[Number_Of_Targets];
		
		AllTargets = new List<Transform> ();


		StartCoroutine (StartUp_Coroutine ());
		StartCoroutine (LoadEggs());



	
	
	}


	// Update is called once per frame
	void Update () {

	}
		


	IEnumerator LoadEggs()
	{




		for (int x = 0; x < Number_Of_Targets;x++) {
			
			BaseObject G; 
			G =	ObjectFactory.TryCreateObject (Egg_Type.BASIC);
			G.name = "BasicEgg";
			G.transform.SetParent (AllTargets[Image_Targets[x]].transform);
			G.transform.localPosition = new Vector3 (0, 0.25f, -0.25f);


			//G.GetComponent<MeshRenderer> ().enabled = false;
			//G.GetComponent<MeshCollider> ().enabled = false;

		}
		
		yield return new WaitForEndOfFrame ();

	}


	public void Object_Collected_Successfully()
	{
		
		C_controller.Object_Visibility_On (Object_Collected_Count);	
		Debug.Log ("Egg_Collected");
		Object_Collected_Count++;
		if (Object_Collected_Count >= Number_Of_Targets) {
			End_Game ();
		}

		C_controller.Object_Count_Change ();
	}

	public void End_Game()
	{
		C_controller.Window_Visibility_On (0);
	}

	IEnumerator StartUp_Coroutine()
	{
		if (Object_Collected_Count <= 0) {
			for (int x = 0; x < 5; x++) {	
				C_controller.Object_Visibility_Off (x);
			}
		}
		for (int x = 0; x < C_controller.Windows.Count; x++) {
			C_controller.Window_Visibility_Off (x);
		}
		foreach (Transform target in TestTarget_list) {
			AllTargets.Add (target);
		}

		for (int i = 0; i < TestTarget_list.childCount; i++) {
			UnUsedIndexes.Add (i);
		}

		int val;
		for (int x = 0; x < Image_Targets.Length; x++) {
			val = Random.Range (0, UnUsedIndexes.Count);
			Image_Targets [x] = UnUsedIndexes [val];
			UnUsedIndexes.RemoveAt (val);
		}
		yield return new WaitForSeconds (0);;
	}
		
	// ======================= Canvas Manager ============================

	public void Explosion_Animation()
	{
		C_controller.Start_Particle_Animation ();
	}
}
