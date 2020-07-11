using UnityEngine;
using UnityEngine.SceneManagement;

public class playerCollision : MonoBehaviour
{
    public playerMovement movement;

    private void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "Obstacle")
        {
            movement.enabled = false;
            FindObjectOfType<gameManager>().endGame();
        }
        if (collisionInfo.collider.tag == "Deal")
        {
            if (collisionInfo.transform.position.y < 0.2)
            {
                FindObjectOfType<dealGenerator>().createDeal();
                if(transform.rotation.y > -0.2 && transform.rotation.y < 0.2)
                    collisionInfo.transform.position = transform.position + new Vector3(0,0.75f,0.6f);
                else if(transform.rotation.y > 0.6 && transform.rotation.y < 0.8)
                    collisionInfo.transform.position = transform.position + new Vector3(0,0.4f,0);
                else if(transform.rotation.y > -0.8 && transform.rotation.y < -0.6)
                    collisionInfo.transform.position = transform.position + new Vector3(0,0.4f,0);
                else
                    collisionInfo.transform.position = transform.position + new Vector3(0,0.4f,0);

                collisionInfo.transform.parent = GameObject.Find("Player").transform;
                collisionInfo.rigidbody.isKinematic = true;
            }
        }
    }
}