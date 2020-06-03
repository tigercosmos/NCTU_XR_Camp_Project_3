using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToStart : MonoBehaviour{
	// Start is called before the first frame update
	void Start(){
		GameObject.FindWithTag("Player").GetComponent<Player>().state = "Run";
		SceneManager.LoadScene("Running");
	}
}
