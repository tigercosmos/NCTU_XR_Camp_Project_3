using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunningDestroy : MonoBehaviour{
	Player PlayerScript;
	// Start is called before the first frame update
	void Start(){
		PlayerScript = GameObject.FindWithTag("Player").GetComponent<Player>();
	}

	// Update is called once per frame
	void Update(){
		if(PlayerScript.state != "Run" && PlayerScript.state != "Running") Destroy(gameObject);
	}
}
