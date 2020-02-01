using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public PlayerManager m_PlayerManager;

    public IRobotArm m_LeftArm;
    public IRobotArm m_RightArm;
    public IRobotLeg m_LeftLeg;
    public IRobotLeg m_RightLeg;

    public IRobotCore m_Torso;
    public IRobotHead m_Head;

    public GameObject psGo;
    private ParticleSystem effect;

    public void SetPlayerManagerLimbs()
    {
        m_LeftArm.thisPM = m_PlayerManager;
        m_RightArm.thisPM = m_PlayerManager;
        m_LeftLeg.thisPM = m_PlayerManager;
        m_RightLeg.thisPM = m_PlayerManager;
        m_Torso.thisPM = m_PlayerManager;
        m_Head.thisPM = m_PlayerManager;
    }

    private void Awake()
    {
        effect = psGo.GetComponent<ParticleSystem>();
        effect.Stop();
        psGo.SetActive(false);
    }

    private void LateUpdate()
    {
        if(effect.isStopped)
        {
            psGo.SetActive(false);
        }
    }


    public void DoRightArmAttack()
    {
        m_RightArm.DoAttack(this.transform);
    }

    public void DoLeftArmAttack()
    {
        m_LeftArm.DoAttack(this.transform);
    }

    private void DoLeftLegAttack()
    {

    }

    private void DoRightLegAttack()
    {

    }

    public void DoRandomDamage(int amount)
    {
        int ran = Random.Range(0, 6);

        Debug.Log("Random Value : " + ran);

        if(ran <= 1)
        {
            m_LeftArm.m_Health -= amount;
            HandleHitEffect(m_LeftArm.transform.position);
        }
        else if(ran > 1 && ran <= 2)
        {
            m_RightArm.m_Health -= amount;
            HandleHitEffect(m_RightArm.transform.position);
        }
        else if (ran > 2 && ran <= 3)
        {
            m_LeftLeg.m_Health -= amount;
            HandleHitEffect(m_LeftLeg.transform.position);
        }
        else if (ran > 3 && ran <= 4)
        {
            m_RightLeg.m_Health -= amount;
            HandleHitEffect(m_RightLeg.transform.position);
        }
        else if (ran > 4 && ran <= 5)
        {
            m_Head.m_Health -= amount;
            HandleHitEffect(m_Head.transform.position);
        }
    }

    public void DestroyAllParts()
    {
        m_LeftArm.m_Health = 0;
        HandleHitEffect(m_LeftArm.transform.position);     
        m_RightArm.m_Health = 0;
        HandleHitEffect(m_RightArm.transform.position);      
        m_LeftLeg.m_Health = 0;
        HandleHitEffect(m_LeftLeg.transform.position);      
        m_RightLeg.m_Health = 0;
        HandleHitEffect(m_RightLeg.transform.position);
        m_Torso.m_Health = 0;
        HandleHitEffect(m_Torso.transform.position);       
        m_Head.m_Health = 0;
        HandleHitEffect(m_Head.transform.position);
    }

    public void HandleHitEffect(Vector3 position)
    {
        psGo.SetActive(true);
        effect.Stop();
        psGo.transform.position = position;
        effect.Play();
    }

}
