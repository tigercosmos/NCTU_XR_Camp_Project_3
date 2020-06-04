using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToStart : MonoBehaviour{
	GameObject Player;
	// Start is called before the first frame update
	void Start(){
		Player = GameObject.FindWithTag("Player");
		//Player.GetComponent<Player>().Run_init();
		//Player.transform.Find("Canvas").gameObject.SetActive(false);
		Player.GetComponent<Player>().state = "Start";
		SceneManager.LoadScene("Start");
	}
}
