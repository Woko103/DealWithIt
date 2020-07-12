using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public AudioSource mainAudio;
    void Update()
    {
        //Resume
        if (Input.anyKeyDown && Time.timeScale == 0)
        {
            pauseMenuUI.SetActive(false);
            Time.timeScale = 1f;
            mainAudio.Play();
        }
        //Pause
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale == 1)
            {
                pauseMenuUI.SetActive(true);
                Time.timeScale = 0f;
                mainAudio.Pause();
            }
        }
    }
}
