using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pController : MonoBehaviour
{
    // Start is called before the first frame update

    public float thrust;

    private Rigidbody rb;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    //FixedUpdate
    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis ("Horizontal");
        float moveVertical = Input.GetAxis ("Vertical");

        Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

        rb.AddForce (movement * thrust);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Pickup"))
        { other.gameObject.SetActive(false); }
    }
}
