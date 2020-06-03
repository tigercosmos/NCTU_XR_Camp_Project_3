using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetCombo : MonoBehaviour{
	GameObject Player;
	// Start is called before the first frame update
	void Start(){
		Player = GameObject.FindWithTag("Player");
	}

	// Update is called once per frame
	void Update(){
		if(Player) gameObject.GetComponent<Text>().text = "" + Player.GetComponent<Player>().combo;
	}
}
