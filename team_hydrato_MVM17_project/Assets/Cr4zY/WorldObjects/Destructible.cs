using System;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Destructible : MonoBehaviour, IHittable
{
    [SerializeField] bool animated;
    [SerializeField] bool particle;
    [SerializeField] AnimationClip clip;
    [SerializeField] int health;
    public void OnHit(PlayerHitBehaviour player)
    {
        Debug.Log(health);
        LoseHealth();
    }

    private void LoseHealth()
    {
        health--;
        if (health > 0)
        {
            return;
        }

        Destroy(GetComponent<Collider2D>());
        if (animated)
        {
            GetComponent<CustomAnimationController>().PlayAnimation(clip, false);
            GetComponent<CustomAnimationController>().animOver += OnAnimEnd;
            return;
        }
        Destroy(gameObject);
    }

    private void OnAnimEnd()
    {
        Destroy(gameObject);
    }
}
