using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerManager : MonoBehaviour
{
    public int m_PlayerNumber;
    public int m_NumScraps;

    public float Horizontal;
    public float Vertical;
    public bool Sprinting;
    public bool RightArmAttack;
    public bool LeftArmAttack;
    public bool RightLegAttack;
    public bool LeftLegAttack;

    private PlayerCombat m_PlayerCombat;
    private PlayerMovement m_PlayerMovement;


    private void Awake()
    {
        m_PlayerCombat = GetComponent<PlayerCombat>();
        m_PlayerCombat.m_PlayerManager = this;
        m_PlayerMovement = GetComponent<PlayerMovement>();
        m_PlayerMovement.m_PlayerManager = this;
    }


    void OnHorizontal(InputValue value)
    {
        Horizontal = value.Get<float>();
    }

    void OnVertical(InputValue value)
    {
        Vertical = value.Get<float>();
    }

    void OnSprint()
    {
        Sprinting = !Sprinting;
    }

    void OnLeftPunch()
    {
        m_PlayerCombat.DoLeftArmAttack();
    }

    void OnRightPunch()
    {
        m_PlayerCombat.DoRightArmAttack();
    }

    void OnRightKick()
    {
        
    }

    void OnLeftKick()
    {

    }
}
