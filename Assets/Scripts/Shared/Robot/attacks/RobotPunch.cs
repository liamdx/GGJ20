﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotPunch : IRobotArm
{

    public int damage = 50;
    public float distance = 1f;
    public float cooldown = 1f;
    public const string rp = "r_punch";
    public const string lp = "l_punch";
    public bool isLeft;
    private float internalCooldown;


    override public void DoAttack(Transform t)
    {
        if (internalCooldown <= 0.0f)
        {
            if (isLeft)
            {
                thisPM.m_Anim.SetBool(lp, true);
            }
            else
            {
                thisPM.m_Anim.SetBool(rp, true);
            }

            Vector3 p1 = t.position + new Vector3(0, 2.5f, 0);
            RaycastHit[] hit;
            hit = Physics.SphereCastAll(p1, 0.5f, t.forward, distance);
            foreach (RaycastHit h in hit)
            {
                if (h.collider.gameObject.GetComponent<PlayerManager>())
                {
                    PlayerManager pm = h.collider.gameObject.GetComponent<PlayerManager>();
                    if (thisPM != pm)
                    {
                        Debug.Log("Hit another player.");
                        pm.DoDamage(damage);
                    }
                }
            }
            Invoke("DisablePunch", 0.1f);
            internalCooldown = cooldown;
        }
    }

    private void Update()
    {
        if(internalCooldown >= 0.0f)
        {
            internalCooldown -= Time.deltaTime;
        }
    }

    void DisablePunch()
    {
        if (isLeft)
        {
            thisPM.m_Anim.SetBool(lp, false);
        }
        else
        {
            thisPM.m_Anim.SetBool(rp, false);
        }
    }
}
