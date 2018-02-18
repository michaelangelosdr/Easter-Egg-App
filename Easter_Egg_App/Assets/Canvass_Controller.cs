using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Canvass_Controller : MonoBehaviour {


	[SerializeField] List<GameObject> Object_Collect_Images;
	[SerializeField] Text Object_Count_Text;
	[SerializeField] public List<GameObject> Windows;

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

	public void Window_Visibility_On(int Window_Index)
	{
		if(Windows[Window_Index].activeInHierarchy == false)
			Windows [Window_Index].SetActive (true);
	}

	public void Window_Visibility_Off(int Window_Index)
	{
		if(Windows[Window_Index].activeInHierarchy == true)
			Windows [Window_Index].SetActive (false);
	}

	public void Button_Function(GameObject button)
	{
		if (button.name == "Win") {
			Debug.Log ("Open win screen");
			SceneManager.LoadScene (2);
		}
	}

}
