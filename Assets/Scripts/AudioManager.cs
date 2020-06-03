using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


public class AudioManager : MonoBehaviour{
	AudioSource BGM;

	// Start is called before the first frame update
	void Start(){
		BGM = GetComponent<AudioSource>();
	}

	// Update is called once per frame
	void Update(){
	}

	public void StartBGM(){
		BGM.Play();
		Debug.Log("play music!");
	}

	public void StopBGM(){
		BGM.Stop();
	}

	public void ChangeBGM(AudioClip music){
		BGM.Stop();
		BGM.clip = music;
		BGM.Play();
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
