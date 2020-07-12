using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gameManager : MonoBehaviour
{
    bool gameHasEnded = false;
    public GameObject loseScreen;
    public GameObject winScreen;
    public AudioSource inGameMusic;

    public void endGame()
    {
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            Invoke("showLoseScreen", 0.5f);
        }
    }

    void Start(){
        inGameMusic.loop = true;
        inGameMusic.volume = 0.5f;
    }

    void Update(){
        inGameMusic.pitch += Time.deltaTime / 700;
    }

    public void loadInGameMusic(){
        inGameMusic.Play();
    }

    void showLoseScreen ()
    {
        loseScreen.SetActive(true);
        Time.timeScale = 0f;
        inGameMusic.Pause();
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
        Time.timeScale = 0f;
        inGameMusic.Pause();
    }
}
