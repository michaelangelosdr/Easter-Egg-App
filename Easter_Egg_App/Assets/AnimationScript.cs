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
	public float timeToAnimateto_screen;
	public float timeToAnimateto_Basket;
	private float curLerptime;
	[SerializeField] GameObject Egg_Particle_SFX;


	//For Editor Uses only
	private Vector3 Tempholder;


	// Use this for initialization
	public	void Start () {
		//Change to player data, for prototype use only.
		MainCamera = Camera.main;
		startPos = EggObject.transform.position;
		Tempholder = startPos;
		FrontOfCamera = Camera.main.ViewportToWorldPoint(new Vector3(0.5f,0.5f,5.0f));
		Debug.Log (Screen.width);
		LowerRightOfScreen = Camera.main.ViewportToWorldPoint(new Vector3(1.0f,-0.01f,5.0f));
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.R)) {
			curLerptime = 0;
			EggObject.transform.position = Tempholder;
		}
		FrontOfCamera = Camera.main.ViewportToWorldPoint(new Vector3(0.5f,0.5f,5.0f));
		Debug.Log (FrontOfCamera);
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
			if (curLerptime >= timeToAnimateto_screen) {curLerptime =timeToAnimateto_screen;}
			float perc = curLerptime /timeToAnimateto_screen;
		EggObject.transform.position = Vector3.Lerp (startPos, FrontOfCamera,perc);
		yield return null;
		}
		Debug.Log ("Done Animation one");
		Egg_Particle_SFX.SetActive(true);
		Egg_Particle_SFX.transform.position = EggObject.transform.position;
		yield return new WaitForSeconds (1.0f);
		StartCoroutine (Anim_PlayOpenAnimation_Coroutine ());
	}
		
	public IEnumerator Anim_PlayOpenAnimation_Coroutine()
	{
		//Enter here if any animations will play after egg gets highlighted

		curLerptime = 0;
		startPos = EggObject.transform.position;
		yield return new WaitForSeconds (timeToAnimateto_screen);
		Egg_Particle_SFX.SetActive (false);
		StartCoroutine (Anim_MoveToBasket_Coroutine());
	}

	public IEnumerator Anim_MoveToBasket_Coroutine()
	{
		while (EggObject.transform.position != LowerRightOfScreen)
		{
			curLerptime += Time.deltaTime;
			if (curLerptime >= timeToAnimateto_Basket) {curLerptime =timeToAnimateto_Basket;}
			float perc = curLerptime / timeToAnimateto_Basket;
			EggObject.transform.position = Vector3.Lerp (startPos,LowerRightOfScreen,perc);
			//EggObject.transform.localScale = Vector3.Lerp (transform.localScale, new Vector3(0.02f,0.02f,0.02f),perc);
			yield return null;
		}
		Debug.Log("Done moving to basket");
		yield return new WaitForSeconds (1.0f);
		//StartCoroutine (Anim_MoveToBasket_Coroutine());
		Debug.Log("Basket is now with an egg");
		GM_Script.IncreaseScore ();
	}



}
