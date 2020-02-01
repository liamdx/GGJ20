using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

enum GameState {
    Menu,
    Repair,
    Combat,
    GameOver
};

public class GameManager : MonoBehaviour{

    public int rounds;
    public List<PlayerManager> players;
    public Camera mainCam;

    private int currentRound;
    private GameState state;
    private PlayerInputManager playerInputManager;

    private void Awake()
    {
        state = GameState.Repair;
        
    }

    public void OnPlayerJoined()
    {
        Debug.Log("Player Joiend");
        PlayerManager[] pms = FindObjectsOfType<PlayerManager>();

        foreach(PlayerManager pm in pms)
        {
            if(pm.m_PlayerNumber == -1)
            {
                pm.m_PlayerNumber = players.Count + 1;
                players.Add(pm);
                pm.IsAlive = true;
            }
        }
    }

    public void OnPlayerDied(PlayerManager player) {
        
    }

    public void OnPlayerLeft()
    {
        Debug.Log("Player Left");
    }



    private void LateUpdate()
    {

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
