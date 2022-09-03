using System;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Collider2D))]
public class DamageZone : MonoBehaviour
{
    [SerializeField] private bool launcher;
    [SerializeField] private float launchPower;
    [SerializeField] private int damage;
    [SerializeField] private Vector2 offset;
    private void Awake()
    {
        GetComponent<Collider2D>().isTrigger = true;
        if (!launcher)
        {
            launchPower = 0;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent<PlayerHurtBehaviour>(out PlayerHurtBehaviour hurt))
        {
            if (launcher)
            {
                hurt.LaunchPlayer((Vector2)transform.position + offset, launchPower);
            }
            hurt.DamagePlayer(damage);
            return;
        }
    }

}
