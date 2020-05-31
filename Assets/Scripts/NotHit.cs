using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NotHit : MonoBehaviour{
	public Text hit;
	public GameObject player;
	// Start is called before the first frame update
	void Start(){
	}

	// Update is called once per frame
	void Update(){
	}

	void OnTriggerEnter(Collider other){
		if(other.gameObject.tag == "brick"){
			hit.text = "Miss";
			player.GetComponent<HitBrick>().counter = 0;
		}
	}
}
