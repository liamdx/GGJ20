using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public int winningPlayer;
    public Text text;

    void Start()
    {
        text.text = PlayerColors.getColorNameByPlayer(winningPlayer) + " Wins";
        text.color = PlayerColors.getColorByPlayer(winningPlayer);
        StartCoroutine(StartCountdown());
    }

    float currCountdownValue;
    public IEnumerator StartCountdown(float countdownValue = 5)
    {
        currCountdownValue = countdownValue;
        while (currCountdownValue > 0)
        {
            Debug.Log("Countdown to main menu: " + currCountdownValue);
            yield return new WaitForSeconds(1.0f);
            currCountdownValue--;
        }

        Debug.Log("Main menu");
        // load main menu
    }
}
