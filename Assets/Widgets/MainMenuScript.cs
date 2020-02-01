using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MainMenuScript : MonoBehaviour
{
    public GameObject MainButtons;
    public GameObject OptionsButtons;
    public GameObject JoinScreen;
    public int MenuSwitch=0;

    // public void PlayPressed()
    // {
    //     MenuSwitch=1;
    //     Debug.Log("PlayPressed");
    // }

    // public void OptionsPressed()
    // {
    //     MenuSwitch=2;
    //     Debug.Log("OptionsPressed");
    // }

    // public void BackPressed()
    // {
    //     MenuSwitch=0;
    //     Debug.Log("BackPressed");
    // }

    // public void ExitPressed()
    // {
    //     MenuSwitch=4;
    //     Debug.Log("EXIT");
    // }

    void Options() 
    {
        MainButtons.SetActive(false);
        OptionsButtons.SetActive(true);
    }

    void MainMenu()
    {
        MainButtons.SetActive(true);
        OptionsButtons.SetActive(false);
    }
    
    void QuitGame()
    {
        Application.Quit();
    }
    
    
}
