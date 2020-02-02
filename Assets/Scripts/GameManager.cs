using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

enum GameState {
    Menu,
    Repair,
    Combat,
};

public class GameManager : MonoBehaviour {

    public int rounds;
    public List<PlayerManager> players;
    public List<Transform> spawns;
    public int[] score = {0,0,0,0};
    public Camera mainCam;

    private int currentRound;
    private GameState state;
    private PlayerInputManager playerInputManager;
    public RepairUIManager repairUImanager;

    public InputAction i;



    private void Awake()
    {
        SetGameState(GameState.Menu);

        
    }

    void DoRoundReset()
    {
        foreach(PlayerManager p in players)
        {
            int index = (int) Random.Range(0, spawns.Count);
            p.ResetPlayer(spawns[index].position);
        }
    }

    private void SetGameState(GameState newState)
    {
        OnGameStateChanged(newState, state);
        state = newState;
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

    private void OnGameStateChanged(GameState newState, GameState oldState)
    {
        
        if(newState == GameState.Repair)
        {
            // show repair UI
            // disable combat
            DoRoundReset();
        }
        if(newState == GameState.Combat)
        {
            // hide repair UI
            // 
        }
        if(newState == GameState.Menu)
        {
            // load menu scene
            // SceneManager.LoadScene(0);
        }
    }


    public void OnPlayerDied()
    {
        int numPlayersAlive = 0;
        int lastAlivePlayerNumber = 0;

        foreach(PlayerManager player in players)
        {
            if (player.IsAlive)
            {
                numPlayersAlive += 1;
                lastAlivePlayerNumber = player.m_PlayerNumber;
            }
        }

        if(currentRound < rounds) 
        {
            
            if (numPlayersAlive == 1)
            {   
                score[lastAlivePlayerNumber] += 1;
                currentRound += 1;
                // Show round won by player color
                SetGameState(GameState.Repair);
            }
        } else {
            // game over
            // load game over scene
        }
    }



    public void OnPlayerLeft()
    {
        Debug.Log("Player Left");
    }
}
