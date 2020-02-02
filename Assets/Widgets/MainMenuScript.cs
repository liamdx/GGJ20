using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class MainMenuScript : MonoBehaviour
{
    private bool b_PlayGame = false;

   

    void OnEnable()
    {
        Debug.Log("Enabled");
    }

    void Disable()
    {
        Debug.Log("disabled");

    }

    public void PlayGame()
    {
        Debug.Log("play");
        b_PlayGame = !b_PlayGame;
        //load level
       
    }

    public void QuitGame()
    {
        Debug.Log("quit");

        //Application.Quit();
    }
    
    
}
