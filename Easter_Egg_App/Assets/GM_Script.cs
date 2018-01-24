using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GM_Script : MonoBehaviour {

	[SerializeField] Transform TestTarget_list;
	private List<Transform> AllTargets;
	public int Number_Of_Targets;
	private int[] Image_Targets;

	private Transform[] targets;
	//private List<GameObject> Targets = GetComponentInChildren<Transform>();



	// Use this for initialization
	void Start () {

		Image_Targets = new int[Number_Of_Targets];
		
		AllTargets = new List<Transform> ();

		foreach (Transform target in TestTarget_list) {
			AllTargets.Add (target);
		}

	

		for (int x = 0; x < Number_Of_Targets; x++) {
			Image_Targets [x] = Random.Range (0, AllTargets.Count);	
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

		}
		
		yield return new WaitForEndOfFrame ();

	}
}
