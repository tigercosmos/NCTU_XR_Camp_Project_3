using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class GetNowTime : MonoBehaviour{
	// Update is called once per frame
	void Update(){
		int h = DateTime.Now.Hour;
		int m = DateTime.Now.Minute;
		gameObject.GetComponent<Text>().text = h/10 + "" + h%10 + ":" + m/10 + "" + m%10;
	}
}
