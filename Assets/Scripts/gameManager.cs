using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gameManager : MonoBehaviour
{
    bool gameHasEnded = false;

    public void endGame()
    {
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            Invoke("showLoseScreen", 1f);
        }
    }

    void showLoseScreen ()
    {
        Debug.Log("Show lose Screen");
    }
}
