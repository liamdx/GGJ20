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
        text.text = PlayerColors.getColorNameByPlayer(winningPlayer) + "Wins";
        text.color = PlayerColors.getColorByPlayer(winningPlayer);
    }
}
