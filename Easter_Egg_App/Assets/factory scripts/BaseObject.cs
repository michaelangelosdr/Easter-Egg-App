using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseObject : MonoBehaviour {




	string Name;
	bool IsCollected;
	Egg_Type egg_type;

	GM_Script GMscript;


	void Awake()
	{
		GMscript = GameObject.Find ("GM").GetComponent<GM_Script> ();
	}


	public virtual void PlayVFX()
	{
		//Insert VFX for objects here
	}



	void OnMouseOver()
	{
		if (Input.GetMouseButtonDown (0)) {
			//Particles.SetActive (true);
			//gameObject.GetComponent<MeshCollider>().enabled = false;
			GMscript.Object_Collected_Successfully();

		}
	}

}
public enum Egg_Type
{
	BASIC,
	SPECIAL,
	GOLDEN,
	BRANDED
}