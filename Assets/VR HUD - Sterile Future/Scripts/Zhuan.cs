﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zhuan : MonoBehaviour
{
    // Start is called before the first frame update

    public int speed = 10;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(Vector3.up * speed);
    }
}
