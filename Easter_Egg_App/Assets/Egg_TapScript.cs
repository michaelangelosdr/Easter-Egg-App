using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Egg_TapScript : MonoBehaviour {


	[SerializeField] AnimationScript ANIM_GMSCRIPT;

	void Awake()
	{
		

	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnMouseOver()
	{
		if (Input.GetMouseButtonDown (0)) {
			//Particles.SetActive (true);
			//gameObject.GetComponent<MeshCollider>().enabled = false;
			ANIM_GMSCRIPT.EggMove_Focus(transform.position);
		
		}
	}

}
