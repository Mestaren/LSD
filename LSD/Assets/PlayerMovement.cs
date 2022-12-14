using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    public bool isSprinting = false;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
   public bool isGrounded = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);


        if (Input.GetButtonDown("Jump") && (isGrounded=true))
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);

            Console.WriteLine("jump");
        }


       // if (Input.GetButtonDown("Jump") && isGrounded)
        {
            //velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);

           // Console.WriteLine("jump");
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        if (Input.GetKey(KeyCode.LeftShift))
        {
            isSprinting = true;
        }
        else
        {
            isSprinting = false;
        }

        if (isSprinting == true)
        {
            speed = 20f;
        }
        else
        {
            speed = 12;
        }
    }
}
