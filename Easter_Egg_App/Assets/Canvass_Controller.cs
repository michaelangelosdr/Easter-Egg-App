using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class Canvass_Controller : MonoBehaviour {


	[SerializeField] List<GameObject> Object_Collect_Images;
	[SerializeField] Text Object_Count_Text;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}



	public void Object_Visibility_On(int Object_Index)
	{
		if(Object_Collect_Images [Object_Index].GetComponent<Image> ().enabled == false)
		Object_Collect_Images [Object_Index].GetComponent<Image> ().enabled = true;
	}

	public void Object_Visibility_Off(int Object_Index)
	{
		if(Object_Collect_Images [Object_Index].GetComponent<Image> ().enabled == true)
			Object_Collect_Images [Object_Index].GetComponent<Image> ().enabled = false;
	}
		
	public void Object_Count_Change()
	{

		Object_Count_Text.text = GM_Script.Object_Collected_Count.ToString();
	}

}
