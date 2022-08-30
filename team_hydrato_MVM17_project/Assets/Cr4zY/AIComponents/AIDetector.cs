using System;
using UnityEngine;
public class AIDetector : MonoBehaviour
{
    private CircleCollider2D noticeRange, attackRange;
    private bool aggro;
    public void Init(float n, float a)
    {
        noticeRange = MakeRangeCollider(nameof(noticeRange), n);
        attackRange = MakeRangeCollider(nameof(attackRange), a);
    }

    private CircleCollider2D MakeRangeCollider(string name, float radius)
    {
        CircleCollider2D collider = new GameObject(nameof(name)).AddComponent<CircleCollider2D>();
        collider.transform.SetParent(transform, false);
        collider.transform.localPosition = Vector3.zero;
        collider.isTrigger = true;
        collider.radius = radius;
        return collider;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(!other.TryGetComponent<CharacterCheckpointer>(out CharacterCheckpointer character))
        {
            return;
        }

        if (aggro)
        {
            if (other.IsTouching(attackRange))
            {
                TryAttack(other.attachedRigidbody);
            }
            return;
        }
        if (other.IsTouching(noticeRange))
        {
            StartAggro(other.attachedRigidbody);
        }
    }

    private void StartAggro(Rigidbody2D attachedRigidbody)
    {
    }

    private void TryAttack(Rigidbody2D attachedRigidbody)
    {
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (!other.TryGetComponent<CharacterCheckpointer>(out CharacterCheckpointer character))
        {
            return;
        }

        if (aggro)
        {
            if (other.IsTouching(attackRange))
            {
                return;
            }
            if (other.IsTouching(noticeRange))
            {
                return;
            }
            StopAggro();
        }

    }

    private void StopAggro()
    {
    }
}

