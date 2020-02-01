using System.Collections;
using System.Collections.Generic;
using UnityEngine;


enum GameState
{
    Menu,
    Repair,
    Combat,
    GameOver
};

public class GameManager : MonoBehaviour
{

    public int rounds;
    public PlayerManager[] players;
    public Camera mainCam;

    private int currentRound;
    private GameState state;

    private void Awake()
    {
        state = GameState.Repair;
    }

    public void UpdatePlayerList()
    {
        players = FindObjectsOfType<PlayerManager>();
    }

    private void LateUpdate()
    {
        UpdatePlayerList();

        if(state == GameState.Repair)
        {

        }
        if(state == GameState.Combat)
        {

        }
        if(state == GameState.GameOver)
        {

        }
        if(state == GameState.Menu)
        {
            // load main menu scene
        }
    }

}
