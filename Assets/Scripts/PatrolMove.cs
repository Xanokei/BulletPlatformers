using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolMove : MonoBehaviour
{
    public GameObject[] waypoint;
    //
    int current = 0;
    float rotSpeed; //Rotation speed
    public float speed;
    float WPradius = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         if(Vector3.Distance(waypoint[current].transform.position, transform.position) < WPradius) 
        {
            current++;
            if (current >= waypoint.Length)
            {
                current = 0;
            }
        }
        transform.position = Vector3.MoveTowards(transform.position, waypoint[current].transform.position, Time.deltaTime * speed);
    }
}