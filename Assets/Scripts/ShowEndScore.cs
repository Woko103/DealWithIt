using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShowEndScore : MonoBehaviour
{
    public TextMeshProUGUI score;

    public TextMeshProUGUI loseScore;

    // Update is called once per frame
    void Update()
    {
        loseScore.text = score.text;
    }
}
