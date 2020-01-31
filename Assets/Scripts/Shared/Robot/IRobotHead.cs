using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IRobotHead : IRobotPart
{
    private SphereCollider m_Col;
    private void Awake()
    {
        m_Col = GetComponent<SphereCollider>();
    }

}
