using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour {

    private CharacterController controller;
    private Vector3 moveVector;

    private float speed = 8.0f;
    private float gravity = 12.0f;
    private float verticalVelocity = 0.0f;
    private float animationDuration = 2.0f;
    private float StartTime;

    private bool isDead = false;
    void Start ()
    {
        controller = GetComponent<CharacterController>();
        StartTime = Time.time;
    }


    void Update()
    {
        if (isDead)
            return;
        if (Time.time - StartTime < animationDuration)
        {
            controller.Move(Vector3.forward * speed * Time.deltaTime);
            return;
        }

            moveVector = Vector3.zero;
            if (controller.isGrounded)
            {
                verticalVelocity = -0.5f;
            }
            else
            {
                verticalVelocity -= gravity * Time.deltaTime;
            }
            // X = left and right, Y = up and down, z = forward and backward 
            moveVector.x = Input.GetAxisRaw("Horizontal") * speed;
            moveVector.y = verticalVelocity;
            moveVector.z = speed;

            controller.Move(moveVector * Time.deltaTime);
        }

    public void Speed(float modifier) //modifies the speed each level the character passes
    {
        speed = 8.0f + modifier;
    }

    private void OnControllerColliderHit(ControllerColliderHit hit) //called when hits an object
    {
        if (hit.point.z > transform.position.z + controller.radius)
            Death();
    }

    private void Death()
    {
        Debug.Log("Dead");
        isDead = true;
        GetComponent<Score>().OnDeath();
    }
}

