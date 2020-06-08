using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour{
	public AudioManager AM;
	public BrickOut BO;
	//GameObject AudioManager, BrickOut;

	void Start(){
		StartGame();
	}

	// Update is called once per frame
	void Update(){
	}

	public void StartGame(){
		var times = AM.GetBeats("Assets/Sounds/beat1.txt");
		foreach (var time in times){
			Debug.Log(time);
		}

		AM.StartBGM();
		BO.GenerateBeats(times);
	}
}
