using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraController : MonoBehaviour
{
    public PlayerMovement[] m_Targs;

    private Camera Par_Camera;

    public Vector3 offset;
    private Vector3 velocity;
    public float smoothTime= 0.5f;

    public float minZoom=40f;
    public float maxZoom=10f;
    public float ZoomLim=50f;

    // Start is called before the first frame update
    void Start()
    {
        Par_Camera=GetComponent<Camera>();
        m_Targs= FindObjectsOfType<PlayerMovement>();

    }

    // Update is called once per frame
    void LateUpdate()
    {
        m_Targs = FindObjectsOfType<PlayerMovement>();

        if (m_Targs.Length==0)
        {return;}

        move();
        zoom();


    }


    void move()
    {
        Vector3 TargPos=GetTargetPosition();
        Vector3 newposition=TargPos+offset;

        Debug.DrawRay(TargPos, Vector3.up);
        
        gameObject.transform.position = Vector3.SmoothDamp(transform.position , newposition , ref velocity, smoothTime) ;
        gameObject.transform.LookAt(TargPos);
    }

    void zoom()
    {
        float Zoomer=Mathf.Lerp(maxZoom,minZoom, getGreatestDistance()/ZoomLim);
        Par_Camera.fieldOfView=Mathf.Lerp(Par_Camera.fieldOfView, Zoomer, Time.deltaTime);
    }


    float getGreatestDistance()
    {
        var bounds = new Bounds(m_Targs[0].transform.position,Vector3.zero);
        
        foreach (PlayerMovement pos in m_Targs)
        {
            bounds.Encapsulate(pos.transform.position);
        }

        return bounds.size.z+bounds.size.x;
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
