using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class playerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public float forwardForce = 4f;
    private bool isGrounded;
    private int timerD = 50;
    private int timerA = 50;
    private int DrotateTime = 21;
    private int ArotateTime = 21;
    public TimerController timeText;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Time.timeScale == 1)
        {
            if(timeText.countTime > 20){
                Debug.Log("Entra");
                rb.position = rb.position + Camera.main.transform.forward * forwardForce * Time.deltaTime;
            }
            else{
                rb.position = rb.position + Camera.main.transform.forward * forwardForce * 2 * Time.deltaTime;
            }

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
                --ArotateTime;
                timerA = 50;
            }
            //Rotate to right
            if (timerD == 0)
            {
                --DrotateTime;
                timerD = 50;
            }

            if (ArotateTime < 21)
            {
                rb.rotation *= Quaternion.Euler(0,-4.5f,0);
                --ArotateTime;
                if(ArotateTime == 0)
                    ArotateTime = 21;
            }
            if (DrotateTime < 21)
            {
                rb.rotation *= Quaternion.Euler(0,4.5f,0);
                --DrotateTime;
                if(DrotateTime == 0)
                    DrotateTime = 21;
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