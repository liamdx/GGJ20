using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MainMenuScript : MonoBehaviour
{
    public GameObject Targ;
    public int MenuSwitch=0;

    public void PlayPressed()
    {
        MenuSwitch=1;
        Debug.Log("PlayPressed");
    }

    public void OptionsPressed()
    {
        MenuSwitch=2;
        Debug.Log("OptionsPressed");
    }

    public void BackPressed()
    {
        MenuSwitch=0;
        Debug.Log("BackPressed");
    }

    public void ExitPressed()
    {
        MenuSwitch=4;
        Debug.Log("EXIT");
    }

}
