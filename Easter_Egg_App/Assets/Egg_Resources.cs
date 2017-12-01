using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Egg_Resources : MonoBehaviour {
	public List<GameObject> Egg_Meshes;
	public int num_Max_Egg_Objects;
	public void Start()
	{
		num_Max_Egg_Objects = Egg_Meshes.Count;
	}
}
