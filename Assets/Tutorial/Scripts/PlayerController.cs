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
    public Vector3 mousePos;
    public Camera playerCam;

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
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= playerSpeed;
            //moveDirection.y = 0;
            //if (Input.GetButton("Jump"))
            if (Input.GetKey(KeyCode.Space))
                moveDirection.y = jumpSpeed;

        }

        else if (characterController.isGrounded == false) // Here I independently allow for both X and Z movement. 

        {
            moveDirection.x = Input.GetAxis("Horizontal") * playerSpeed;
            moveDirection.z = Input.GetAxis("Vertical") * playerSpeed;
            moveDirection = transform.TransformDirection(moveDirection);// Then reassign the current transform to the Vector 3.
        }


        // Apply gravity. Gravity is multiplied by deltaTime twice (once here, and once below
        // when the moveDirection is multiplied by deltaTime). This is because gravity should be applied
        // as an acceleration (ms^-2)
        moveDirection.y -= gravity * Time.deltaTime;

        // Move the controller
        characterController.Move(moveDirection * Time.deltaTime);

        Ray cameraRay = playerCam.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayLength;

        if (groundPlane.Raycast(cameraRay, out rayLength))
        {
            Vector3 mousePos = cameraRay.GetPoint(rayLength);
            Debug.DrawLine(cameraRay.origin, mousePos, Color.blue);
            transform.LookAt(new Vector3(mousePos.x, transform.position.y, mousePos.z));
        }
    }
    void FixedUpdate()
    {
        if (rb.position.y < -10f)
        {
            FindObjectOfType<GameManager>().EndGame();
        }
    }

    //COLLISION DETECTION FOR DEATH
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("TRIGGER COLLIDER");
        bool death = false;
        //Layer 11 == "Death" layer
        if (other.gameObject.layer == 11)
        {
            death = true;
        }
        //layer 12 == "Bullet" layer
        else if (other.gameObject.layer == 12) 
        {
            Debug.Log("COLLIDER BULLET");
            //Application.Quit();
            death = true;
        }
        if (death == true)
        {
            other.gameObject.SetActive(false);
            rb.gameObject.SetActive(false);
            FindObjectOfType<GameManager>().EndGame();
        }

    }

}
