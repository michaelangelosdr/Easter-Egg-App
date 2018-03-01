using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SplashScreen_Script : MonoBehaviour {

	[SerializeField] Text Loading_Text_Val;
	[SerializeField] GameObject Loading_Text_Gameobject;
	[SerializeField] GameObject Title_Text;

	void Awake()
	{

	}
		


	public void LoadScenes()
	{
		Debug.Log ("Change now");
		Title_Text.SetActive (false);
		Loading_Text_Gameobject.SetActive (true);
		StartCoroutine (LoadSceneAsynchronously (1));
	}

	IEnumerator LoadSceneAsynchronously(int index)
	{

		AsyncOperation Operation = SceneManager.LoadSceneAsync (index);


		while(!Operation.isDone)
			{

			float progress = Mathf.Clamp01 (Operation.progress / .9f);

			Debug.Log (progress);
			Loading_Text_Val.text = (progress * 100f).ToString();
			yield return null;
			}
	}
}
