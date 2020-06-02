using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonOnClick : MonoBehaviour{
	GameObject Player;
	void Start(){
		
	}
	void Update(){
		Vector3[] rect = new Vector3[4];
		gameObject.GetComponent<RectTransform>().GetWorldCorners(rect);
		string Out = gameObject.name + ": ";
		for(int i = 0; i < 4; i++){
			Out += rect[i].ToString("f6");
			if(i != 3) Out += ", ";
		}
		Debug.Log(Out);
	}
}