using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public void Init(PlayerHurtBehaviour player)
    {
        GetComponentInChildren<HealthBar>().Init(player);
    }
}
