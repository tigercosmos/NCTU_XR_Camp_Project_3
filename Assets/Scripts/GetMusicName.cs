using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetMusicName : MonoBehaviour{
	public string[] name_list;
	public int music_idx, origin_idx;
	Text name;

	void Start(){
		name = GetComponent<Text>();
	}

	void Update(){
		name.text = name_list[music_idx];
	}

	void OnEnable(){
		origin_idx = GameObject.FindWithTag("Player").GetComponent<Player>().music_idx;
		music_idx = origin_idx;
	}
}
