using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour{
	public int combo, speed, speed_floor;
	public string state;
	float speed_timer, speed_integrate;
	public Material OntrackMat, NotOntrackMat;
	AudioSource Audio;
	bool Ontrack;
	GameObject Cursor;

	void Start(){
		DontDestroyOnLoad(this.gameObject);
		Audio = transform.Find("AudioPlayer").gameObject.GetComponent<AudioSource>();
		Cursor = transform.Find("Canvas/Cursor").gameObject;
		Cursor.SetActive(true);
		combo = 0;
		speed = 0;
		speed_timer = 0;
		speed_integrate = 0;
		Ontrack = false;
		state = "Start";
	}

	void Update(){
		if(state == "Running"){
			speed_timer += Time.deltaTime;
			speed_integrate += transform.position.y;
			speed = (int)(transform.position.y / Time.deltaTime * 0.001);
			if(speed_timer > 5){
				int avg_speed = (int)(speed_integrate / speed_timer * 0.001);
				if(avg_speed < speed_floor){
					//lower then speed_floor, game fail
				}
				speed_timer = 0;
				speed_integrate = 0;
			}
		}
		transform.position = new Vector3(transform.position.x, 0, 0);
		var headPosition = transform.position;
		var gazeDirection = transform.forward;
		RaycastHit hitInfo;
		if(Physics.Raycast(headPosition, gazeDirection, out hitInfo)){
			GameObject target = hitInfo.collider.gameObject;
			if(target.transform.tag == "UI collider"){
				target.GetComponent<BUTTONS>().Hover();
			}
		}
	}

	public void ChangeMusic(AudioClip music){
		Audio.clip = music;
	}

	public float PlayMusic(){ //play music and return music length in sec
		Audio.Play();
		if(Audio.clip) return Audio.clip.length;
		else return 0;
	}

	void OnTriggerEnter(Collider other){
		if(other.gameObject.tag == "brick"){
			combo++;
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
