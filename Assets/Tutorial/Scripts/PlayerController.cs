using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    CharacterController characterController;
    public float playerSpeed = 6.0f;
    public float jumpSpeed = 5.0f;
    public float gravity = 20.0f;
    private Vector3 moveDirection = Vector3.zero;

    //for collision
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();

        //For collission/death
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (characterController.isGrounded)
        {
            // We are grounded, so recalculate
            // move direction directly from axes

            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
            moveDirection *= playerSpeed;

            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpSpeed;
            }
        }

        // Apply gravity. Gravity is multiplied by deltaTime twice (once here, and once below
        // when the moveDirection is multiplied by deltaTime). This is because gravity should be applied
        // as an acceleration (ms^-2) needs to add Velocity
        moveDirection.y -= gravity * Time.deltaTime;

        // Move the controller
        characterController.Move(moveDirection * Time.deltaTime);
    }
    void FixedUpdate()
    {

    }



    //COLLISION DETECTION FOR DEATH
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("TRIGGER COLLIDER");
        //Layer 11 == "Death" layer
        if (other.gameObject.layer == 11)
        {
            rb.gameObject.SetActive(false);
            other.gameObject.SetActive(false);
        }
        //layer 12 == "Bullet" layer
        else if (other.gameObject.layer == 12) 
        {
            Debug.Log("COLLIDER BULLET");
            other.gameObject.SetActive(false);
            rb.gameObject.SetActive(false);
        }
    }

}
