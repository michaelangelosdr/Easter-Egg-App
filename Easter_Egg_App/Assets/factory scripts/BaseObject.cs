using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseObject : MonoBehaviour {




	string Name;
	bool IsCollected;
	Egg_Type egg_type;

	public virtual void PlayVFX()
	{
		//Insert VFX for objects here


	}

	void On2DTriggerEnter(Collider col)
	{
		Debug.Log (col.gameObject);
	}


}
public enum Egg_Type
{
	BASIC,
	SPECIAL,
	GOLDEN,
	BRANDED
}