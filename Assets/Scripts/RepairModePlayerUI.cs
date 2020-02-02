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
        c.transform.position = cam.WorldToScreenPoint(associatedPlayer.transform.position);
        if(enabled)
        {
            c.enabled = true;
        }
        else
        {
            c.enabled = false;
        }
    }
}
