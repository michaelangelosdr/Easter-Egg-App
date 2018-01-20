using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM_Script : MonoBehaviour {

	// Use this for initialization
	void Start () {

		ObjectFactory.TryCreateObject (Egg_Type.BASIC);

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
