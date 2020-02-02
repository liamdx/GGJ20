using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RepairModePlayerUI : MonoBehaviour
{
    Canvas c;
    public Camera cam;
    public PlayerManager associatedPlayer;
    public bool enabled;

    public Text headValue;
    public Text legsValue;
    public Text armsValue;
    public Text scrapValue;


    private void Start()
    {
        c = GetComponent<Canvas>();
        enabled = false;
        cam = associatedPlayer.m_GameManager.mainCam;
    }

    private void LateUpdate()
    {   
        if(enabled)
        {
            c.enabled = true;
            c.transform.position = cam.WorldToScreenPoint(associatedPlayer.transform.position);
        }
        else
        {
            c.enabled = false;
        }

        UpdateUI();
    }


    void UpdateUI()
    {
        int headHealth = associatedPlayer.m_PlayerCombat.m_Head.m_Health;
        int coreHealth = associatedPlayer.m_PlayerCombat.m_Torso.m_Health;
        int leftLegHealth = associatedPlayer.m_PlayerCombat.m_LeftLeg.m_Health;
        int rightLegHealth = associatedPlayer.m_PlayerCombat.m_RightLeg.m_Health;
        int leftArmHealth = associatedPlayer.m_PlayerCombat.m_LeftArm.m_Health;
        int rightArmHealth = associatedPlayer.m_PlayerCombat.m_RightArm.m_Health;


        int _headValue = (headHealth + coreHealth) / 2;
        int _armsValue = (leftArmHealth + rightArmHealth) / 2;
        int _legsValue = (leftLegHealth + rightLegHealth) / 2;

        headValue.text = _headValue.ToString();
        armsValue.text = _armsValue.ToString();
        legsValue.text = _legsValue.ToString();
    }
}
