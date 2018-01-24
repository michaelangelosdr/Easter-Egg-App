using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectFactory : MonoBehaviour {

	private static ObjectFactory instance = null;

	[SerializeField] GameObject Egg_prefab;
	[SerializeField] List<Material> _Materials;


	void Awake()
	{
		instance = this;
	}
	void OnDestroy()
	{
		instance = null;
	}



	public static BaseObject TryCreateObject(Egg_Type egg_type)
	{

		if (instance == null) {
			return null;
		}

		return instance.Createobject (egg_type);
	}


	private BaseObject CreateObjectInstance(GameObject _prefab, Material _mat)
	{
		GameObject inst = GameObject.Instantiate (_prefab) as GameObject;
		inst.GetComponent<Renderer> ().material = _mat;
		BaseObject baseObject = inst.GetComponent<BaseObject> ();
		return baseObject;
	}

	public BaseObject Createobject(Egg_Type egg_type)
	{
		BaseObject _object = null;	


		switch (egg_type) {

		case Egg_Type.BASIC:
			_object = this.CreateObjectInstance (Egg_prefab, _Materials[0]);
			break;
		case Egg_Type.SPECIAL:
			_object = this.CreateObjectInstance (Egg_prefab, _Materials [0]);
			break;
		case Egg_Type.GOLDEN:
			_object = this.CreateObjectInstance (Egg_prefab, _Materials [0]);
			break;

		}
		return _object;

	}

}
