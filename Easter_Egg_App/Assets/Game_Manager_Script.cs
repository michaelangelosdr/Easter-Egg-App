using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Manager_Script : MonoBehaviour {

	public int NUM_EggsCollected;

	[SerializeField] Egg_Resources Egg_Resource_Handler;
	[SerializeField] AnimationScript Animation_Handler;
	[SerializeField] CanvasController_Script Canvas_Handler;

	void Start()
	{
		Debug.Log ("Initializing..");
		Animation_Handler.Start ();
		Egg_Resource_Handler.Start ();
		Canvas_Handler.Start ();
	}	


	public void IncreaseScore()
	{
		NUM_EggsCollected++;
		Canvas_Handler.Change_ScoreText ();
	}

}
