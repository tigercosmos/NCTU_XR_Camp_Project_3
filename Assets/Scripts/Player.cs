using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour{
	public int combo, max_combo, speed, speed_floor, score, music_idx;
	public float timer, dict;
	public string state;
	public Material OntrackMat, NotOntrackMat;
	public AudioClip Eat, Bump, Click;
	public Vector3 HitPoint;
	bool Ontrack;
	GameObject Cursor_true, Cursor_false;
	AudioSource Effect;

	void Start(){
		DontDestroyOnLoad(this.gameObject);
		Cursor_false = transform.Find("Canvas/FalseCursor").gameObject;
		Cursor_true = transform.Find("Canvas/TrueCursor").gameObject;
		Effect = transform.Find("Effect").gameObject.GetComponent<AudioSource>();
		Cursor_true.SetActive(false);
		Run_init();
		music_idx = 1;
		HitPoint = new Vector3(0, 0, 0);
	}

	void Update(){
		if(state == "Running"){
			speed = (int)(transform.position.y / Time.deltaTime * 0.001);
			timer += Time.deltaTime;
			dict += transform.position.y;
		}

		//reset camera position to (origin x, 0, 0)
		transform.position = new Vector3(transform.position.x, 0, 0);

		//get gaze position on UI
		var headPosition = transform.position;
		var gazeDirection = transform.forward;
		RaycastHit hitInfo;
		if(Physics.Raycast(headPosition, gazeDirection, out hitInfo)){
			GameObject target = hitInfo.collider.gameObject;
			if(target.transform.tag == "UI collider"){
				target.GetComponent<BUTTONS>().Hover();
				Cursor_false.SetActive(false);
				Cursor_true.SetActive(true);
			}
			else{
				Cursor_false.SetActive(true);
				Cursor_true.SetActive(false);
			}
			HitPoint = hitInfo.point;
		}
		else{
			Cursor_false.SetActive(true);
			Cursor_true.SetActive(false);
		}
	}

	public void Run_init(){
		combo = 0;
		max_combo = 0;
		speed = 0;
		timer = 0;
		dict = 0;
		Ontrack = false;
		score = 0;
	}

	public void Sound(string cmd){
		if(Effect.isPlaying) Effect.Stop();
		if(cmd == "Eat") Effect.clip = Eat;
		else if(cmd == "Bump") Effect.clip = Bump;
		else if(cmd == "Click") Effect.clip = Click;

		Effect.Play();
	}

	void OnTriggerEnter(Collider other){
		if(other.gameObject.tag == "brick"){
			combo++;
			if(combo > max_combo) max_combo = combo;
			score += combo;
			Sound("Eat");
		}
		else if(other.gameObject.tag == "obstacle"){
			combo = 0;
			Sound("Bump");
		}
	}

	void OnTriggerStay(Collider other){
		if(other.gameObject.tag == "track" && Ontrack == false){
			Ontrack = true;
			other.gameObject.GetComponent<Renderer>().material = OntrackMat;
		}
	}

	void OnTriggerExit(Collider other){
		if(other.gameObject.tag == "track"){
			Ontrack = false;
			other.gameObject.GetComponent<Renderer>().material = NotOntrackMat;
		}
	}
}
