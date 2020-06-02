using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BUTTONS : MonoBehaviour{
	public string action;
	GameObject button;

	void Start(){
		button = transform.parent.gameObject;
	}

	public void Hover(){
		Debug.Log(button.name + " hover");
	}

	public void Click(){
		Debug.Log(button.name + " click");
		/*
		if(action == "Start") ToStart();
		else if(action == "Exit") Exit();
		else if(action == "GameLevel") ToGameLevel();
		else if(action == "WarmUp") ToWarmUp();
		else if(action == "MusicSelect") ToMusicSelect();
		else if(action == "Running") ToRunning();
		else return false;

		return true;
		*/
	}

	void ToStart(){
		SceneManager.LoadScene("Start");
	}

	void Exit(){
		Debug.Log("Exit");
	}

	void ToGameLevel(){
		SceneManager.LoadScene("GameLevel");
	}

	void ToWarmUp(){
		SceneManager.LoadScene("WarmUp");
	}

	void ToMusicSelect(){
		SceneManager.LoadScene("MusicSelect");
	}

	void ToRunning(){
		SceneManager.LoadScene("Running");
	}
}
