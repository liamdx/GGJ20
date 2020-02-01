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
    public bool IsAlive;

    private PlayerCombat m_PlayerCombat;
    private PlayerMovement m_PlayerMovement;
    public Animator m_Anim;

    private void Awake()
    {
        m_PlayerNumber = -1;
        IsAlive = true;
        m_PlayerCombat = GetComponent<PlayerCombat>();
        m_PlayerCombat.m_PlayerManager = this;
        m_PlayerCombat.SetPlayerManagerLimbs();
        m_PlayerMovement = GetComponent<PlayerMovement>();
        m_PlayerMovement.m_PlayerManager = this;
        m_Anim = GetComponent<Animator>();
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
        if (IsAlive)
        {
            // play punch animation
            m_PlayerCombat.DoLeftArmAttack();
        }
    }

    void OnRightPunch()
    {
        if (IsAlive)
        {
            // play punch animation
            m_PlayerCombat.DoRightArmAttack();
        }
    }

    void OnRightKick()
    {
        
    }

    void OnLeftKick()
    {

    }

    public void DoDamage(int amount)
    {
        m_PlayerCombat.DoRandomDamage(amount);
    }

    public void Die()
    {
        IsAlive = false;
    }
}
