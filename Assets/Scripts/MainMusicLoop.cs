using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMusicLoop : MonoBehaviour
{
    public AudioSource mainMusic;
    void Start()
    {
        mainMusic.loop = true;
        mainMusic.volume = 0.5f;
    }

    // Update is called once per frame
    public void loadMainMusic()
    {
        mainMusic.Play();
    }
}
