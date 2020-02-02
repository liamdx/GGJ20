using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : IPickup
{
    public int healthToAdd = 10;
    public override void DoAction()
    {
        base.DoAction();
        playerPickingUp.m_PlayerCombat.AddHealthToParts(healthToAdd);
    }

}
