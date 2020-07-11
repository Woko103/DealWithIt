﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class playerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public float forwardForce = 4f;
    private bool isGrounded;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Time.timeScale == 1)
        {
            float x = rb.rotation.y;
            float z = rb.rotation.y - 1;
            rb.MovePosition(new Vector3(rb.position.x * (1+x),rb.position.y,rb.position.z+forwardForce*Time.deltaTime*z));

            //Right move
            if (Input.GetKey("d"))
            {
                rb.MovePosition(new Vector3(rb.position.x+4f*Time.deltaTime,rb.position.y,rb.position.z));
            }
            //Left move
            if (Input.GetKey("a"))
            {
                rb.MovePosition(new Vector3(rb.position.x-4f*Time.deltaTime,rb.position.y,rb.position.z));
            }
            //Jump
            if (isGrounded && Input.GetKey("space"))
            {
                rb.AddForce(0,100*Time.deltaTime,0,ForceMode.VelocityChange);
            }
        }
    }

    private void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "Ground")
        {
            Invoke("setGroundedToTrue", 0.3f);
        }
    }
    private void OnCollisionExit(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "Ground")
        {
            isGrounded = false;
        }
    }
    private void setGroundedToTrue()
    {
        isGrounded = true;
    }
}