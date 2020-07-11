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
            FindObjectOfType<dealGenerator>().createDeal();
            collisionInfo.transform.position = transform.position + new Vector3(0,1,0);
        }
    }
}