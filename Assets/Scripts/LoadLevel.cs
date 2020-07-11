using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{
    public void LoadNextLevel()
    {
        Scene scene = SceneManager.GetActiveScene();
        int sceneNum = scene.buildIndex;

        if (sceneNum >= SceneManager.sceneCountInBuildSettings - 1)
        {
            SceneManager.LoadScene(0);
        }
        else
        {
            SceneManager.LoadScene(sceneNum + 1);
        }
    }

    public void ResetLevel()
    {
        Scene scene = SceneManager.GetActiveScene();
        int sceneNum = scene.buildIndex;
        SceneManager.LoadScene(sceneNum);
    }
}