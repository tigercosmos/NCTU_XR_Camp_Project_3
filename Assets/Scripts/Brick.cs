using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour{
	public float speed;
	// Start is called before the first frame update
	void Start(){
	}

	// Update is called once per frame
	void Update(){
		transform.Translate(0, 0, -speed*Time.deltaTime);
	}

	void OnTriggerEnter(Collider other){
		if(other.gameObject.tag == "Player"){
			Destroy(gameObject);
		}
	}
}
