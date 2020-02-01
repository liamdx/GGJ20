using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotPunch : IRobotArm
{

    public int damage;

    override public void DoAttack(Transform t)
    {
        Vector3 p1 = t.position + new Vector3(0, 2.5f, 0);

        RaycastHit[] hit;
        hit = Physics.SphereCastAll(p1, 3.0f, t.forward, 30);
        foreach(RaycastHit h in hit)
        {
            if (h.collider.gameObject.GetComponent<PlayerManager>())
            {
                PlayerManager pm = h.collider.gameObject.GetComponent<PlayerManager>();
                if(thisPM != pm)
                {
                    Debug.Log("Hit another player.");
                    pm.DoDamage(damage);
                }
                

            }
        }
        
    }
}
