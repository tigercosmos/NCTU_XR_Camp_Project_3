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
		Player.GetComponent<Player>().Sound("Click");
		if(action == "Start") ToStart();
		else if(action == "WarmUp") ToWarmUp();
		else if(action == "WarmUpStart") WarmUpStart();
		else if(action == "WarmUpEnd") WarmUpEnd();
		else if(action == "GameLevel") ToGameLevel();
		else if(action == "MusicSelect") ToMusicSelect();
		else if(action == "m1") SelectMusic(1);
		else if(action == "m2") SelectMusic(2);
		else if(action == "m3") SelectMusic(3);
		else if(action == "Running") ToRunning();
		else if(action == "SetTrack") SetTrack();
		else if(action == "MusicChange") ToMusicChange();
		else if(action == "Pause") Pause();
		else if(action == "madd") MusicAdd();
		else if(action == "msub") MusicSub();
		else if(action == "Return") Return();
		else if(action == "Score") ToScore();
		else if(action == "Exit") Exit();
	}

	void ToStart(){
		GameObject.FindWithTag("Player").GetComponent<Player>().state = "Start";
		SceneManager.LoadScene("Start");
	}

	void ToWarmUp(){
		GameObject.FindWithTag("Player").GetComponent<Player>().state = "WarmUp";
		SceneManager.LoadScene("WarmUp");
	}

	void WarmUpStart(){
		GameObject.Find("start").SetActive(false);
		GetComponent<SetActive>().Active();
	}

	void WarmUpEnd(){
		GetComponent<SetActive>().Active();
	}

	void ToGameLevel(){
		GameObject.FindWithTag("Player").GetComponent<Player>().state = "GameLevel";
		SceneManager.LoadScene("GameLevel");
	}

	void ToMusicSelect(){
		GameObject.FindWithTag("Player").GetComponent<Player>().state = "MusicSelect";
		SceneManager.LoadScene("MusicSelect");
	}

	void SelectMusic(int idx){
		if(idx >= 1 && idx <= 3){
			Player.GetComponent<Player>().music_idx = idx-1;
			ToRunning();
		}
	}

	void ToRunning(){
		Player.GetComponent<Player>().Run_init();
		Player.transform.Find("Canvas").gameObject.SetActive(false);
		Player.GetComponent<Player>().state = "Run";
		SceneManager.LoadScene("Running");
	}

	void SetTrack(){
		GameObject.Find("Tracks").GetComponent<SetParent>().UnbindParent();
		GameObject.Find("Managers").GetComponent<SetParent>().UnbindParent();
		Player.transform.Find("Canvas").gameObject.SetActive(true);
		Player.GetComponent<Player>().state = "Running";
		GameObject.Find("GameManager").GetComponent<GameManager>().StartGame();
		GetComponent<SetActive>().Active();
		GameObject.Find("READY").SetActive(false);
	}

	void ToMusicChange(){
		Player.GetComponent<Player>().state = "MusicChange";
		SceneManager.LoadScene("MusicChange");
	}

	void Pause(){
		GameObject.Find("Tracks").SetActive(false);
		GetComponent<SetActive>().Active();
		CanvasFollow PCscript = GameObject.Find("PauseCanvas").GetComponent<CanvasFollow>();
		PCscript.BindParent();
		PCscript.UnbindParent();
		GameObject[] Bricks = GameObject.FindGameObjectsWithTag("brick");
		foreach(GameObject b in Bricks) b.GetComponent<Brick>().Pause();
		GameObject[] Obstacles = GameObject.FindGameObjectsWithTag("obstacle");
		foreach(GameObject o in Obstacles) o.GetComponent<Brick>().Pause();
		GameObject.Find("GameManager").GetComponent<GameManager>().PauseGame();
		GameObject.Find("RunningCanvas").SetActive(false);
	}

	void MusicAdd(){
		int new_idx = GameObject.Find("music_name").GetComponent<GetMusicName>().music_idx;
		new_idx = (new_idx + 1)%3;
		GameObject.Find("music_name").GetComponent<GetMusicName>().music_idx = new_idx;
	}

	void MusicSub(){
		int new_idx = GameObject.Find("music_name").GetComponent<GetMusicName>().music_idx;
		new_idx = (new_idx + 2)%3;
		GameObject.Find("music_name").GetComponent<GetMusicName>().music_idx = new_idx;
	}

	void Return(){
		GetComponent<SetActive>().Active();
		GetMusicName GMN = GameObject.Find("music_name").GetComponent<GetMusicName>();
		if(GMN.origin_idx != GMN.music_idx){
			Player.GetComponent<Player>().music_idx = GMN.music_idx;
			GameObject[] Bricks = GameObject.FindGameObjectsWithTag("brick");
			foreach(GameObject b in Bricks) Destroy(b);
			GameObject[] Obstacles = GameObject.FindGameObjectsWithTag("obstacle");
			foreach(GameObject o in Obstacles) Destroy(o);
			Player.GetComponent<Player>().Run_init();
			GameObject.Find("GameManager").GetComponent<GameManager>().StopGame();
			GameObject.Find("GameManager").GetComponent<GameManager>().StartGame();
			GameObject.Find("PauseCanvas").SetActive(false);
		}
		else{
			GameObject[] Bricks = GameObject.FindGameObjectsWithTag("brick");
			foreach(GameObject b in Bricks) b.GetComponent<Brick>().Continue();
			GameObject[] Obstacles = GameObject.FindGameObjectsWithTag("obstacle");
			foreach(GameObject o in Obstacles) o.GetComponent<Brick>().Continue();
			GameObject.Find("GameManager").GetComponent<GameManager>().ReplayGame();
			GameObject.Find("PauseCanvas").SetActive(false);
		}
	}

	void ToScore(){
		Player.GetComponent<Player>().state = "Score";
		SceneManager.LoadScene("Score");
	}

	void Exit(){
		Application.Quit();
	}
}
