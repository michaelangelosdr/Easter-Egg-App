using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationScript : MonoBehaviour {

	public GameObject EggObject;
	private Vector3 startPos;
	private Vector3 endPos;
	public float lerpTime;
	private float curLerptime;



	// Use this for initialization
	void Start () {
		startPos = EggObject.transform.position;
		endPos = new Vector3 (0, 0, 8);
		//StartCoroutine (MoveEgg_Coroutine ());
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	public void EggMove_Focus(Vector3 t)
	{
		startPos = t;
		StartCoroutine (MoveEgg_Coroutine ());
	}

	public IEnumerator MoveEgg_Coroutine()
	{



		while (EggObject.transform.position != endPos)
		{
			curLerptime += Time.deltaTime;
			if (curLerptime >= lerpTime) {
				curLerptime = lerpTime;
			}


		float perc = curLerptime / lerpTime;

		EggObject.transform.position = Vector3.Lerp (startPos, endPos,perc);
			yield return null;
		}

		yield return new WaitForSeconds (lerpTime);
		Debug.Log ("ITS DONE");
	}
}
