using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepairModePlayerUI : MonoBehaviour
{
    Canvas c;
    public Camera cam;
    public PlayerManager associatedPlayer;
    public bool enabled;

    private void Start()
    {
        c = GetComponent<Canvas>();
        enabled = false;
    }

    private void LateUpdate()
    {   
        if(enabled)
        {
            c.enabled = true;
            c.transform.position = cam.WorldToScreenPoint(associatedPlayer.transform.position);
        }
        else
        {
            c.enabled = false;
        }
    }
}
