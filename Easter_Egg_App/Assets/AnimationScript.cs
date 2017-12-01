using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimationScript : MonoBehaviour {

	Camera MainCamera;

	[SerializeField] Game_Manager_Script GM_Script;
	public GameObject EggObject;
	private Vector3 startPos;
	private Vector3 FrontOfCamera;
	private Vector3 LowerRightOfScreen;
	public float lerpTime;
	private float curLerptime;



	//For Editor Uses only
	private Vector3 Tempholder;


	// Use this for initialization
	public	void Start () {
		//Change to player data, for prototype use only.
		MainCamera = Camera.main;
		startPos = EggObject.transform.position;
		Tempholder = startPos;
		FrontOfCamera = new Vector3 (0, 0, 9);
		Debug.Log (Screen.width);
		LowerRightOfScreen = new Vector3 (6, -4, 9);
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.R)) {
			curLerptime = 0;
			EggObject.transform.position = Tempholder;
		}

	}


	public void EggMove_Focus(Vector3 t)
	{
		startPos = t;
		StartCoroutine (Anim_MoveToFrontScreen_Coroutine());
	}

	public IEnumerator Anim_MoveToFrontScreen_Coroutine()
	{
		while (EggObject.transform.position != FrontOfCamera)
		{
		curLerptime += Time.deltaTime;
		if (curLerptime >= lerpTime) {curLerptime = lerpTime;}
		float perc = curLerptime / lerpTime;
		EggObject.transform.position = Vector3.Lerp (startPos, FrontOfCamera,perc);
		yield return null;
		}
		Debug.Log ("Done Animation one");
		yield return new WaitForSeconds (1.0f);
		StartCoroutine (Anim_PlayOpenAnimation_Coroutine ());
	}
		
	public IEnumerator Anim_PlayOpenAnimation_Coroutine()
	{
		//Enter here if any animations will play after egg gets highlighted
		curLerptime = 0;
		startPos = EggObject.transform.position;
		yield return new WaitForSeconds (lerpTime);
		StartCoroutine (Anim_MoveToBasket_Coroutine());
	}

	public IEnumerator Anim_MoveToBasket_Coroutine()
	{
		while (EggObject.transform.position != LowerRightOfScreen)
		{
			curLerptime += Time.deltaTime;
			if (curLerptime >= lerpTime) {curLerptime = lerpTime;}
			float perc = curLerptime / lerpTime;
			EggObject.transform.position = Vector3.Lerp (startPos,LowerRightOfScreen,perc);
			yield return null;
		}
		Debug.Log("Done moving to basket");
		yield return new WaitForSeconds (lerpTime);
		//StartCoroutine (Anim_MoveToBasket_Coroutine());
		Debug.Log("Basket is now with an egg");
		GM_Script.IncreaseScore ();
	}



}
