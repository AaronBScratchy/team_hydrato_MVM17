using System;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Collider2D))]
public class DamageZone : MonoBehaviour
{
    [SerializeField] private bool launcher;
    [SerializeField] private float launchPower;
    [SerializeField] private int damage;
    private void Awake()
    {
        if (!launcher)
        {
            launchPower = 0;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<PlayerHurtBehaviour>(out PlayerHurtBehaviour hurt))
        {
            if (launcher)
            {
                hurt.LaunchPlayer(collision.GetContact(0).point, launchPower);
            }
            hurt.DamagePlayer(damage);

        }
    }

}
