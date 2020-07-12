using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimerController : MonoBehaviour
{
    public int countTime =60;
    public TextMeshProUGUI display;

    private void Start(){
        StartCoroutine(CountdownToStart());
    }

    IEnumerator CountdownToStart(){
        while(countTime > 0){
            display.text = countTime.ToString();

            yield return new WaitForSeconds(1f);

            countTime--;
        }

        yield return new WaitForSeconds(1f);

        display.gameObject.SetActive(false);

        FindObjectOfType<gameManager>().endGame();
    }
}
