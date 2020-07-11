using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gameManager : MonoBehaviour
{
    bool gameHasEnded = false;
    public GameObject loseScreen;
    public GameObject winScreen;

    public void endGame()
    {
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            Invoke("showLoseScreen", 0.5f);
        }
    }

    void showLoseScreen ()
    {
        loseScreen.SetActive(true);
    }

    public void winGame()
    {
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            Invoke("showWinScreen", 0.5f);
        }
    }

    void showWinScreen ()
    {
        winScreen.SetActive(true);
    }
}
