using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


public class AudioManager : MonoBehaviour{
	public AudioSource BGM;
	public AudioClip[] music;

	public void StartBGM(){
		int music_idx = GameObject.FindWithTag("Player").GetComponent<Player>().music_idx;
		BGM.clip = music[music_idx];
		BGM.Play();
		Debug.Log("play music!");
	}

	public void PauseBGM(){
		BGM.Pause();
	}

	public void ReplayBGM(){
		BGM.Play();
	}

	public void StopBGM(){
		BGM.Stop();
	}

	public ArrayList GetBeats(string path){
		var times = new ArrayList();

		StreamReader reader = new StreamReader(path);
		while (!reader.EndOfStream){
			string line = reader.ReadLine();
			times.Add(line);
		}
		reader.Close();

		return times;
	}
}
