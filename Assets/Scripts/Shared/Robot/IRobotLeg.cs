using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IRobotLeg : IRobotPart
{
    // pass through the root player objects transform.
    void DoAttack(Transform t)
    {
        // play some animation;
        // do some form of attack
        Debug.Log("Doing attack");

    }
}
