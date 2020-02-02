using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepairUIManager : MonoBehaviour
{
    public List<RepairModePlayerUI> PlayerRepairUIs;
    public GameManager gameManager;

    private void Awake()
    {
        for(int i = 0; i < 4; i++)
        {
            PlayerRepairUIs.Add(new RepairModePlayerUI());
        }

    }

    public void AttachPlayersToUI()
    {
        for(int i = 0; i < gameManager.players.Count; i++)
        {
            PlayerRepairUIs[i].associatedPlayer = gameManager.players[i];
        }
    }

    public void EnableRepairUI()
    {
        for (int i = 0; i < gameManager.players.Count; i++)
        {
            PlayerRepairUIs[i].enabled = true;
        }
    }

    public void DisableRepairUI()
    {
        for (int i = 0; i < gameManager.players.Count; i++)
        {
            PlayerRepairUIs[i].enabled = false;
        }
    }
}
