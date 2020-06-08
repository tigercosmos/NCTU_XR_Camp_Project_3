using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickOut : MonoBehaviour{
	public GameObject Brick;
	GameObject O1, O2;
	private string[] times;
	private int counter = 0;
	private float start_time;
	// Start is called before the first frame update
	void Start(){
		Transform Ot1 = transform.Find("Out1");
		if(Ot1) O1 = Ot1.gameObject;
		Transform Ot2 = transform.Find("Out2");
		if(Ot2) O2 = Ot2.gameObject;
	}

    // Update is called once per frame
    void Update(){
        var ball_come_time = 40/10; // distance / velocity
        var time = Time.time - start_time + ball_come_time;

		if(time >= float.Parse(times[counter])){
			Debug.Log("time pass: " + time + ".Generate a beat.");
			if (Random.Range(0.0f, 2.0f) > 1){
				Instantiate(Brick, O1.transform.position, O1.transform.rotation);
			}
			else{
				Instantiate(Brick, O2.transform.position, O2.transform.rotation);
			}
			counter += 1;
		}
	}

	public void GenerateBeats(ArrayList times){
		this.times = (string[])times.ToArray(typeof(string));
		start_time = Time.time;
	}
}
