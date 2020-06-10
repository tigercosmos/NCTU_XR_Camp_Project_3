using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasFollow : MonoBehaviour{
	public Vector3 Origin;

	void Update(){
        Player PlayerScript = GameObject.FindWithTag("Player").GetComponent<Player>();
		if(PlayerScript.state != "Run" && PlayerScript.state != "Running") Destroy(gameObject);
	}

	public void UnbindParent(){
		transform.parent = null;
	}

	public void BindParent(){
		transform.parent = GameObject.FindWithTag("Player").transform;
		transform.localPosition = Origin;
		transform.localRotation = Quaternion.identity;
	}
}
