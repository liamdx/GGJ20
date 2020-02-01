using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoyN : MonoBehaviour
{
    public void Destroy(float delay)
    {
        Invoke("DoDestroy", delay);
    }
    private void DoDestroy()
    {
        DestroyImmediate(this.gameObject);
    }

}
