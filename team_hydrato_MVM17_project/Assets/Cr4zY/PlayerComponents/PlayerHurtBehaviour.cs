using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHurtBehaviour : MonoBehaviour
{
    private CharacterMovement movement;
    private CharacterStateMachine stateMachine;
    private CharacterCheckpointer checkPointer;
    private int Health;
    private int maxHealth;
    private bool IB;
    public Action hurt;
    public void Init()
    {
        movement = GetComponent<CharacterMovement>();
        stateMachine = GetComponent<CharacterStateMachine>();
        checkPointer = GetComponent<CharacterCheckpointer>();

        maxHealth = 4;
        Health = maxHealth;

        checkPointer.onDeath += OnRespawn;
    }

    private void OnRespawn()
    {
        Health = maxHealth;
    }

    public void DamagePlayer(int damage)
    {
        if (IB)
        {
            return;
        }
        TakeDamage(damage);
    }

    public void LaunchPlayer(Vector2 from, float launchPower)
    {
        if (IB)
        {
            return;
        }
        movement.Launch(from, launchPower);
    }

    private void TakeDamage(int damageToTake)
    {
        for(int i = 0; i < damageToTake; i++)
        {
            Health--;

            hurt?.Invoke();

            if (Health == 0)
            {
                checkPointer.onDeath?.Invoke();
                break;
            }
        }

        IB = true;
        Invoke(nameof(TurnOffIB), 1.25f);
    }

    private void TurnOffIB()
    {
        IB = false;
    }
}
