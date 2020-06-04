using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetParent : MonoBehaviour{
	public Vector3 Origin;
	// Start is called before the first frame update
	void Start(){
		GameObject Player = GameObject.FindWithTag("Player");
		if(Player){
			transform.parent = Player.transform;
			transform.localPosition = Origin;
			transform.localRotation = Quaternion.identity;
		}
	}

	public void UnbindParent(){
		transform.parent = null;
	}
}
