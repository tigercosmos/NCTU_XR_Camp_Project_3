using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamaManager : MonoBehaviour
{

    public AudioManager AM;
    public BrickOut BO;

    void Start()
    {
        StartGame();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartGame()
    {
        var times = AM.GetBeats();
        foreach (var time in times)
        {
            Debug.Log(time);
        }

        AM.StartBGM();
        BO.GenerateBeats(times);
    }

}
