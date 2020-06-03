﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NotHit : MonoBehaviour{
	GameObject Player;
	// Start is called before the first frame update
	void Start(){
		Player = GameObject.FindWithTag("Player");
	}

	void OnTriggerEnter(Collider other){
		if(other.gameObject.tag == "brick"){
			if(Player) Player.GetComponent<Player>().combo = 0;
		}
	}
}
