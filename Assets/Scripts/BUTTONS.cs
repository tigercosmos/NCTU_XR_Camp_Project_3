using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BUTTONS : MonoBehaviour{
	public string action;
	//public bool Radio, Checked;
	//public GameObject[] ButtonsEnvokeGroup;
	GameObject Button, TrueImg, Player;
	string[] MusicList;
	bool isHover;
	Vector3[] rect;

	void Start(){
		Button = transform.parent.gameObject;
		Player = GameObject.FindWithTag("Player");
		Transform TrueImgTrans = Button.transform.Find("TrueImage");
		if(TrueImgTrans){
			TrueImg = TrueImgTrans.gameObject;
			if(!TrueImg.activeInHierarchy) TrueImg = null;
		}
		else TrueImg = null;
		if(TrueImg) TrueImg.SetActive(false);
		isHover = false;
		rect = new Vector3[4];
		Button.GetComponent<RectTransform>().GetWorldCorners(rect);

		//music name list
		MusicList = new string[3];
		MusicList[0] = "";
		MusicList[1] = "";
		MusicList[2] = "";
	}

	void Update(){
		if(isHover){
			isHover = Blur();
			if(!isHover && TrueImg) TrueImg.SetActive(false);
		}
	}

	public void Hover(){
		if(TrueImg) TrueImg.SetActive(true);
		isHover = true;
	}

	bool Blur(){
		Vector3 point = Player.GetComponent<Player>().HitPoint;
		return point.x > rect[0].x && point.x < rect[2].x && point.y > rect[0].y && point.y < rect[2].y;
	}

	public void Click(){
		Debug.Log(Button.name + " click");
		//SetChecked(true);
		if(action == "Start") ToStart();
		else if(action == "GameLevel") ToGameLevel();
		else if(action == "MusicSelect") ToMusicSelect();
		else if(action == "WarmUp") ToWarmUp();
		else if(action == "WarmUpStart") WarmUpStart();
		//else if(action == "WarmUpEnd") WarmUpEnd();
		else if(action == "Running") ToRunning();
		else if(action == "SetTrack") SetTrack();
		else if(action == "MusicChange") ToMusicChange();
		else if(action == "Pause") Pause();
		else if(action == "Score") ToScore();
		else if(action == "Exit") Exit();
	}

	void ToStart(){
		GameObject.FindWithTag("Player").GetComponent<Player>().state = "Start";
		SceneManager.LoadScene("Start");
	}

	void ToGameLevel(){
		GameObject.FindWithTag("Player").GetComponent<Player>().state = "GameLevel";
		SceneManager.LoadScene("GameLevel");
	}

	void ToMusicSelect(){
		GameObject.FindWithTag("Player").GetComponent<Player>().state = "MusicSelect";
		SceneManager.LoadScene("MusicSelect");
	}

	void SelectMusic(string music){
	}

	void ToWarmUp(){
		GameObject.FindWithTag("Player").GetComponent<Player>().state = "WarmUp";
		SceneManager.LoadScene("WarmUp");
	}

	void WarmUpStart(){
		GameObject.Find("start").SetActive(false);
		WarmUpEnd();
	}

	void WarmUpEnd(){
		GetComponent<SetActive>().Active();
	}

	void ToRunning(){
		Player.GetComponent<Player>().Run_init();
		Player.transform.Find("Canvas").gameObject.SetActive(false);
		Player.GetComponent<Player>().state = "Run";
		SceneManager.LoadScene("Running");
	}

	void SetTrack(){
		GameObject.Find("Tracks").GetComponent<SetParent>().UnbindParent();
		GameObject.Find("Buttons").transform.position = Player.transform.position;
		GameObject.Find("Buttons").transform.rotation = Player.transform.rotation;
		GameObject.Find("Buttons").GetComponent<SetActive>().Active();
		Player.transform.Find("Canvas").gameObject.SetActive(true);
		Player.GetComponent<Player>().state = "Running";
		GameObject.Find("GameManager").GetComponent<GameManager>().StartGame();
		GameObject.Find("READY").SetActive(false);
	}

	void ToMusicChange(){
		Player.GetComponent<Player>().state = "MusicChange";
		SceneManager.LoadScene("MusicChange");
	}

	void Pause(){
		Debug.Log("Pause");
	}

	void ToScore(){
		Player.GetComponent<Player>().state = "Score";
		SceneManager.LoadScene("Score");
	}

	void Exit(){
		Debug.Log("Exit");
	}
}
