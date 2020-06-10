using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour{
	public float speed;
	bool stop;
	// Start is called before the first frame update
	void Start(){
		stop = false;
	}

	// Update is called once per frame
	void Update(){
		if(!stop) transform.Translate(0, 0, -speed*Time.deltaTime);
	}

	void OnTriggerEnter(Collider other){
		if(other.gameObject.tag == "Player" || other.gameObject.name == "Wall"){
			if(!stop) Destroy(gameObject);
		}
	}

	public void Pause(){
		stop = true;
		transform.GetChild(0).gameObject.SetActive(false);
	}

	public void Continue(){
		stop = false;
		transform.GetChild(0).gameObject.SetActive(true);
	}
}
