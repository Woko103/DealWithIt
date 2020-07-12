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
    private bool wet = false;
    private int wetCount = 200;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Time.timeScale == 1)
        {
            if(timeText.countTime > 30){
                if(wet){
                    rb.position = rb.position + gameObject.transform.forward * forwardForce * 2 * Time.deltaTime;

                    wetCount--;
                    if(wetCount == 0){
                        wet = false;
                        wetCount = 200;
                    }  
                }
                else{
                    rb.position = rb.position + gameObject.transform.forward * forwardForce * Time.deltaTime;
                }
            }
            else if(timeText.countTime > 15){
                if(wet){
                    rb.position = rb.position + gameObject.transform.forward * forwardForce * 2 * Time.deltaTime;

                    wetCount--;
                    if(wetCount == 0){
                        wet = false;
                        wetCount = 200;
                    }  
                }
                else{
                    rb.position = rb.position + gameObject.transform.forward * forwardForce * 1.5f * Time.deltaTime;
                }
            }
            else{
                if(wet){
                    rb.position = rb.position + gameObject.transform.forward * forwardForce * 2.5f * Time.deltaTime;

                    wetCount--;
                    if(wetCount == 0){
                        wet = false;
                        wetCount = 200;
                    }  
                }
                else{
                    rb.position = rb.position + gameObject.transform.forward * forwardForce * 2 * Time.deltaTime;
                }
            }

            //When you stop holding the button, the rotation timer stops
            if (Input.GetKeyUp("d") || Input.GetKeyUp("right"))
            {
                timerD = 50;
            }
            if (Input.GetKeyUp("a") || Input.GetKeyUp("left"))
            {
                timerA = 50;
            }

            //Right move
            if (Input.GetKey("d") || Input.GetKey("right"))
            {
                rb.position = rb.position + gameObject.transform.right * 5f * Time.deltaTime;
                --timerD;
            }
            //Left move
            else if (Input.GetKey("a") || Input.GetKey("left"))
            {
                rb.position = rb.position + gameObject.transform.right * -5f * Time.deltaTime;
                --timerA;
            }
            //Jump
            if (isGrounded && Input.GetKey("space"))
            {
                rb.AddForce(0,100*Time.deltaTime,0,ForceMode.VelocityChange);
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

            //Rotating to left
            if (ArotateTime < 21)
            {
                rb.rotation *= Quaternion.Euler(0,-4.5f,0);
                --ArotateTime;
                if(ArotateTime == 0)
                    ArotateTime = 21;
            }
            //Rotating to right
            if (DrotateTime < 21)
            {
                rb.rotation *= Quaternion.Euler(0,4.5f,0);
                --DrotateTime;
                if(DrotateTime == 0)
                    DrotateTime = 21;
            }

                Debug.Log("x:" + transform.rotation.x);
                Debug.Log("z:" + transform.rotation.z);
            //You lose if you rotate to the ground
            if (transform.rotation.z > 0.8f || transform.rotation.z < -0.8f || transform.rotation.x > 0.7f || transform.rotation.x < -0.7f)
            {
                //Debug.Log("x:" + transform.rotation.x);
                //Debug.Log("z:" + transform.rotation.z);
                FindObjectOfType<gameManager>().endGame();
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

    private void OnTriggerEnter(Collider collisionInfo){
        if(collisionInfo.tag == "WetFloor" && !wet){
            wet = true;
        }
    }
    private void setGroundedToTrue()
    {
        isGrounded = true;
    }
}