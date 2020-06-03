using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetParent : MonoBehaviour{
	// Start is called before the first frame update
	void Start(){
		GameObject Player = GameObject.FindWithTag("Player");
		if(Player){
			transform.parent = Player.transform;
			transform.localPosition = new Vector3(0, 0, 0);
			transform.localRotation = Quaternion.identity;
		}
	}

	public void UnbindParent(){
		transform.parent = null;
	}
}
