using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHurtBehaviour : MonoBehaviour
{
    private CharacterMovement movement;
    private CharacterStateMachine stateMachine;
    private CharacterCheckpointer checkPointer;
    private int _health;
    public int Health { get { return _health; }}
    private int _maxHealth;
    public int MaxHealth { get { return _maxHealth; }}
    private bool IB;
    public Action hurt,damageTaken;
    public void Init()
    {
        movement = GetComponent<CharacterMovement>();
        stateMachine = GetComponent<CharacterStateMachine>();
        checkPointer = GetComponent<CharacterCheckpointer>();
        IB = false;
        _maxHealth = 4;
        _health = _maxHealth;

        checkPointer.onDeath += OnRespawn;
    }

    private void OnRespawn()
    {
        _health = _maxHealth;
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
        hurt?.Invoke();
        for (int i = 0; i < damageToTake; i++)
        {
            _health--;
            damageTaken?.Invoke();
            if (_health == 0)
            {
                Die();
                break;
            }
        }

        ToggleIB();
        Invoke(nameof(ToggleIB), 1.25f);
    }

    public void Die()
    {
        checkPointer.onDeath?.Invoke();
    }

    public void ToggleIB()
    {
        IB = !IB;
    }
}
