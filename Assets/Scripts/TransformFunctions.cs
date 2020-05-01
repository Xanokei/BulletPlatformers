using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformFunctions : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float turnSpeed = 400f;
    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = 20f;
    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetKey(KeyCode.W))
        {
            if (Input.GetKey(KeyCode.Space))
            {
                moveSpeed = 40f;
                transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
            }
            else
            {
                moveSpeed = 20f;
                transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
            }
            
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(-Vector3.forward * moveSpeed * Time.deltaTime);
        }


        if (Input.GetKey(KeyCode.A))
            transform.Rotate(Vector3.up, -turnSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.D))
            transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime);

        //if (Input.GetKey(KeyCode.LeftArrow))
        //{
        //    transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        //}


        //if (Input.GetKey(KeyCode.RightArrow))
        //{
        //    transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
        //}
    }
}
