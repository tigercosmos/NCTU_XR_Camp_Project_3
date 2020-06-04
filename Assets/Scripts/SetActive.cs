using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetActive : MonoBehaviour{
	public GameObject[] Obj;

	public void Active(){
		for(int i = 0; i < Obj.Length; i++) Obj[i].SetActive(true);
	}
}
