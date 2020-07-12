using UnityEngine;
using UnityEngine.SceneManagement;

public class playerCollision : MonoBehaviour
{
    public playerMovement movement;
    public AudioSource crash;
    public AudioSource pickDeal;
    public AudioSource cans;

    void Start(){
        crash.volume = 0.5f;
        pickDeal.volume = 0.5f;
    }

    private void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "Obstacle")
        {
            crash.Play();
            movement.enabled = false;
            FindObjectOfType<gameManager>().endGame();
        }
        if (collisionInfo.collider.tag == "Deal")
        {
            pickDeal.Play();
            if (collisionInfo.transform.position.y < 0.2)
            {
                FindObjectOfType<dealGenerator>().createDeal();
                int actualTime = FindObjectOfType<TimerController>().countTime;
                FindObjectOfType<ScoreController>().moreScore(50 + 60 + actualTime);
                if(transform.rotation.y > -0.2 && transform.rotation.y < 0.2)
                    collisionInfo.transform.position = transform.position + new Vector3(0,0.75f,0.6f);
                else if(transform.rotation.y > 0.6 && transform.rotation.y < 0.8)
                    collisionInfo.transform.position = transform.position + new Vector3(0.6f,0.75f,0);
                else if(transform.rotation.y > -0.8 && transform.rotation.y < -0.6)
                    collisionInfo.transform.position = transform.position + new Vector3(-0.6f,0.75f,0);
                else
                    collisionInfo.transform.position = transform.position + new Vector3(0,0.75f,-0.6f);

                collisionInfo.transform.parent = GameObject.Find("Player").transform;
                collisionInfo.rigidbody.isKinematic = true;
            }
        }
        if(collisionInfo.collider.tag == "Can"){
            cans.Play();
        }
    }
}