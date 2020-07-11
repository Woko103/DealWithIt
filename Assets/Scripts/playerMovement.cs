using UnityEngine;
using UnityEngine.SceneManagement;

public class playerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public float forwardForce = 4f;
    private bool isGrounded;
    private int timerD = 50;
    private int timerA = 50;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Time.timeScale == 1)
        {
            rb.position = rb.position + Camera.main.transform.forward * forwardForce * Time.deltaTime;

            //When you stop holding the button, the rotation timer stops
            if (Input.GetKeyUp("d"))
            {
                timerD = 50;
            }
            if (Input.GetKeyUp("a"))
            {
                timerA = 50;
            }

            //Right move
            if (Input.GetKey("d"))
            {
                rb.MovePosition(new Vector3(rb.position.x+6f*Time.deltaTime*Camera.main.transform.right.x,rb.position.y,rb.position.z));
                --timerD;
            }
            //Left move
            else if (Input.GetKey("a"))
            {
                rb.MovePosition(new Vector3(rb.position.x-6f*Time.deltaTime*Camera.main.transform.right.x,rb.position.y,rb.position.z));
                --timerA;
            }
            //Jump
            if (isGrounded && Input.GetKeyDown("space"))
            {
                rb.AddForce(0,120*Time.deltaTime,0,ForceMode.VelocityChange);
            }

            //Rotate to left
            if (timerA == 0)
            {
                rb.rotation *= Quaternion.Euler(0,-90,0);
                timerA = 50;
            }
            //Rotate to right
            if (timerD == 0)
            {
                rb.rotation *= Quaternion.Euler(0,90,0);
                timerD = 50;
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