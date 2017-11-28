using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpMovement : MonoBehaviour {


	public GameObject EggObject;

	public Vector3 startPos;

	public Vector3 endPos;

	private float Distance = 30f;

	private float lerptime = 1;

	private float curlerptime = 0;

	private bool keyhit = false;


	// Use this for initialization
	void Start () {

		startPos = EggObject.transform.position;

		endPos = new Vector3 (0, 0, 8);

	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.Space)) {
			keyhit = true;
		}

		if (keyhit) {
			curlerptime += Time.deltaTime;
			if (curlerptime >= lerptime) {
				curlerptime = lerptime;
			}
		}

		float perc = curlerptime / lerptime;

		EggObject.transform.position = Vector3.Lerp (startPos, endPos,perc);
	}
}
