using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseCanvas : MonoBehaviour{
	public Vector3 Origin;
	void OnEnable(){
		GameObject Player = GameObject.FindWithTag("Player");
		if(Player){
			transform.parent = Player.transform;
			transform.localPosition = Origin;
			transform.localRotation = Quaternion.identity;
		}
		transform.parent = null;
	}
}
