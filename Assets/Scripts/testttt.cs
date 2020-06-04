using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testttt : MonoBehaviour{
    // Start is called before the first frame update
    void Start(){
    }

    // Update is called once per frame
    void Update(){
        if(Input.GetKeyDown(KeyCode.UpArrow)) transform.Translate(0, 0, 1);
        else if(Input.GetKeyDown(KeyCode.DownArrow)) transform.Translate(0, 0, -1);
        else if(Input.GetKeyDown(KeyCode.RightArrow)) transform.Translate(1, 0, 0);
        else if(Input.GetKeyDown(KeyCode.LeftArrow)) transform.Translate(-1, 0, 0);
        else if(Input.GetKeyDown(KeyCode.R)) transform.position = new Vector3(transform.position.x, 0, 0);
    }
}
