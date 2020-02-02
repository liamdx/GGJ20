using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IPickup : MonoBehaviour
{
    private SphereCollider col;

    public PlayerManager playerPickingUp;

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<PlayerManager>())
        {
            playerPickingUp = other.GetComponent<PlayerManager>();
            DoAction();
            Destroy(this.gameObject);
        }
    }

    public virtual void DoAction() {   }
}
