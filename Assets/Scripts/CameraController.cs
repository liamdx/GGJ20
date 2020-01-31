using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public PlayerMovement[] m_Targs;

    private Camera Par_Camera;

    public Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        
        m_Targs= FindObjectsOfType<PlayerMovement>();

    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (m_Targs.Length==0)
        {return;}
        Vector3 TargPos=GetTargetPosition();
        Vector3 newposition=TargPos+offset;

        Debug.DrawRay(TargPos, Vector3.up);
        
        gameObject.transform.position = newposition;
        gameObject.transform.LookAt(TargPos);

    }

    Vector3 GetTargetPosition()
    {
        var bounds = new Bounds (m_Targs[0].transform.position, Vector3.zero);

        foreach (PlayerMovement pos in m_Targs)
        {
            bounds.Encapsulate(pos.transform.position);
        }
        return bounds.center;
    }
}
