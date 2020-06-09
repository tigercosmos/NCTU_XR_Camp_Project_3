using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickOut : MonoBehaviour
{
    public GameObject Brick;
    public GameObject Obstacle;
    GameObject star1, star2, obstacle1, obstacle2;
    private string[] times;
    private int counter = 0;
    private float start_time;
    // Start is called before the first frame update
    void Start()
    {
        Transform s1 = transform.Find("Star1");
        if (s1)
        {
            star1 = s1.gameObject;
        }
        Transform s2 = transform.Find("Star2");
        if (s2)
        {
            star2 = s2.gameObject;
        }

        Transform o1 = transform.Find("Obstacle1");
        if (o1)
        {
            obstacle1 = o1.gameObject;
        }
        Transform o2 = transform.Find("Obstacle2");
        if (o2)
        {
            obstacle2 = o2.gameObject;
        }
    }

    // Update is called once per frame
    void Update()
    {
        var ball_come_time = 40 / 10; // distance / velocity
        var time = Time.time - start_time + ball_come_time;

        if (time >= float.Parse(times[counter]))
        {
            //Debug.Log("time pass: " + time + ".Generate a beat.");
            if (Random.Range(0.0f, 2.0f) > 1)
            {
                Instantiate(Brick, star1.transform.position, star1.transform.rotation);
            }
            else
            {
                Instantiate(Brick, star2.transform.position, star2.transform.rotation);
            }
            counter += 1;
        }
        if ( Time.time % 5 < 0.01)
        {
            Debug.Log("time pass: " + time + ".Generate an obstacle.");
            if (Random.Range(0.0f, 2.0f) > 1)
            {
                Instantiate(Obstacle, obstacle1.transform.position, obstacle1.transform.rotation);
            }
            else
            {
                Instantiate(Obstacle, obstacle2.transform.position, obstacle2.transform.rotation);
            }
        }
    }

    public void GenerateBeats(ArrayList times)
    {
        this.times = (string[])times.ToArray(typeof(string));
        start_time = Time.time;
    }
}
