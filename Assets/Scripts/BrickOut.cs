using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickOut : MonoBehaviour
{
    public GameObject O1, O2, Brick;
    private string[] times;
    private int counter = 0;
    private float start_time;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        var time = Time.time - start_time;

        if (time >= float.Parse(times[counter]))
        {
			Debug.Log("time pass: " + time + ".Generate a beat.");
            if (Random.Range(0.0f, 2.0f) > 1)
            {
                Instantiate(Brick, O1.transform.position, O1.transform.rotation);
            }
            else
            {
                Instantiate(Brick, O2.transform.position, O2.transform.rotation);
            }
			counter += 1;
        }
    }

    public void GenerateBeats(ArrayList times)
    {
        this.times = (string[])times.ToArray(typeof(string));
        start_time = Time.time;
    }
}
