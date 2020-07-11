using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreController : MonoBehaviour
{

    public int scoreCount = 0;
    public TextMeshProUGUI display;

    public void moreScore(int s){
        scoreCount = scoreCount + s;
        display.text = scoreCount.ToString();
    }
}
