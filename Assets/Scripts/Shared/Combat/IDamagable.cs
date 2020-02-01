using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IDamagable : MonoBehaviour
{
    public void DoDamage(IRobotPart part, int damage)
    {
        part.m_Health -= damage;
    }
}
