using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour{
	public AudioManager AM;
	public BrickOut BO;
	//GameObject AudioManager, BrickOut;

	void Start(){
		// StartGame(); // for testing
	}

	// Update is called once per frame
	void Update(){
	}

	public void StartGame(){
		string beat_name = "Assets/Sounds/beat";
		beat_name += (GameObject.FindWithTag("Player").GetComponent<Player>().music_idx + 1);
		beat_name += ".txt";
		var times = AM.GetBeats(beat_name);
		foreach (var time in times){
			Debug.Log(time);
		}

		AM.StartBGM();
		BO.GenerateBeats(times);
	}

	public void PauseGame(){
		AM.PauseBGM();
		BO.Pause();
	}

	public void ReplayGame(){
		AM.ReplayBGM();
		BO.Replay();
	}

	public void StopGame(){
		AM.StopBGM();
	}
}
