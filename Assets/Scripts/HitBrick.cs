using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HitBrick : MonoBehaviour{
	// Start is called before the first frame update
	public int counter;
	bool Ontrack;
	public Material OntrackMat, NotOntrackMat;
	public Text hit;
	void Start(){
		counter = 0;
		Ontrack = false;
	}

	// Update is called once per frame
	void Update(){
		transform.position = new Vector3(this.transform.position.x, 0, 0);
	}

	void OnTriggerEnter(Collider other){
		if(other.gameObject.tag == "brick"){
			counter++;
			hit.text = "Combo: " + counter;
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
