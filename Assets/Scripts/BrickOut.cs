using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickOut : MonoBehaviour{
	public GameObject O1, O2, Brick;
	public float cycletime;
	float timer;
	// Start is called before the first frame update
	void Start(){
		timer = cycletime;
	}

	// Update is called once per frame
	void Update(){
		timer += Time.deltaTime;
		if(timer >= cycletime){
			timer = 0.0f;
			if(Random.Range(0.0f, 2.0f) > 1){
				Instantiate(Brick, O1.transform.position, O1.transform.rotation);
			}
			else{
				Instantiate(Brick, O2.transform.position, O2.transform.rotation);
			}
		}
	}
}
