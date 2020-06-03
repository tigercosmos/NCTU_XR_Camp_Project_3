using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class GetNowTime : MonoBehaviour{
	// Update is called once per frame
	void Update(){
		gameObject.GetComponent<Text>().text = DateTime.Now.Hour + ":" + DateTime.Now.Minute;
	}
}
