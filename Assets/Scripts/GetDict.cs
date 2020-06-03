using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetDict : MonoBehaviour{
	GameObject Player;
	// Start is called before the first frame update
	void Start(){
		Player = GameObject.FindWithTag("Player");
	}

	// Update is called once per frame
	void Update(){
		float dict = 0;
		if(Player) dict = Player.GetComponent<Player>().dict;
		dict *= 0.001f;
		gameObject.GetComponent<Text>().text = dict.ToString("f2");
	}
}
