using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoControl : MonoBehaviour{
	VideoPlayer v;
	// Start is called before the first frame update
	void Start(){
		v = gameObject.GetComponent<VideoPlayer>();
		v.Play();
	}

	// Update is called once per frame
	void Update(){
		if(v.frame > 0 && !v.isPlaying){
			gameObject.GetComponent<BUTTONS>().Click();
			Destroy(gameObject);
		}
	}
}
