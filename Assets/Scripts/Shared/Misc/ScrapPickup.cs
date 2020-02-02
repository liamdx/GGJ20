using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrapPickup : IPickup {

    public int scrapToAdd = 2;

    public override void DoAction()
    {
        base.DoAction();
        playerPickingUp.m_NumScraps += scrapToAdd;
    }


}
