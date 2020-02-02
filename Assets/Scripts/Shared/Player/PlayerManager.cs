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

    public PlayerCombat m_PlayerCombat;
    public PlayerMovement m_PlayerMovement;
    public GameManager m_GameManager;
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
        m_GameManager = FindObjectOfType<GameManager>();
        m_PlayerMovement.m_Rib.isKinematic = true;
        transform.position = m_GameManager.GetSpawnPoint();
        m_PlayerMovement.m_Rib.isKinematic = false;
    }

    public void ResetPlayer(Vector3 startPosition)
    {
        m_PlayerCombat.SetLimbsNotBroken();
        if(!IsAlive)
        {
            m_PlayerCombat.SetHealthAllParts(20);
        }
        else
        {
            m_PlayerCombat.AddHealthToParts(20);
        }
        m_PlayerMovement.m_Rib.isKinematic = true;
        transform.position = startPosition;
        m_PlayerMovement.m_Rib.isKinematic = false;
        SetRepairMode();
    }


    void SetRepairMode()
    {
        m_PlayerMovement.m_CanMove = false;
        m_PlayerCombat.m_CanAttack = false;
    }

    public void SetCombatMode()
    {
        IsAlive = true;
        m_PlayerMovement.m_CanMove = true;
        m_PlayerCombat.m_CanAttack = true;
    }

    void SetGameOver()
    {
        m_PlayerMovement.m_CanMove = false;
        m_PlayerCombat.m_CanAttack = false;
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
        m_PlayerCombat.DestroyAllParts();
        m_GameManager.OnPlayerDied();
    }

}
