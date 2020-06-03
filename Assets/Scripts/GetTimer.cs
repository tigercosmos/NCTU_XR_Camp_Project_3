using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetTimer : MonoBehaviour{
	GameObject Player;
	// Start is called before the first frame update
	void Start(){
		Player = GameObject.FindWithTag("Player");
	}

	// Update is called once per frame
	void Update(){
		int secs = 0;
		if(Player) secs = (int)(Player.GetComponent<Player>().timer);
		int mins = secs/60;
		gameObject.GetComponent<Text>().text = mins/10 + "" + mins%10 + ":" + (secs%60)/10 + "" + secs%600;
	}
}
