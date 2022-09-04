using System;
using UnityEngine;
public class AIHurtBehaviour : MonoBehaviour, IHittable
{
    [SerializeField] int health;
    public Action onHurt;
    public void OnHit(PlayerHitBehaviour player)
    {

        health--;

        if (health > 0)
        {
            Vector2 launchdir = (transform.position - player.transform.position).normalized + Vector3.up;
            GetComponent<AINavigator>().Launch(launchdir.normalized);
            onHurt?.Invoke();
            return;
        }

        Die();

    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
