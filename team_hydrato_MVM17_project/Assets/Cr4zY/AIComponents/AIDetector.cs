using System;
using UnityEngine;
public class AIDetector : MonoBehaviour
{
    private CircleCollider2D noticeRange, attackRange;
    private bool aggro, canAttack;
    [SerializeField] private float attackCD, suspicionTimer;
    public Action attackAttempt, onAggroStart, onAggroEnd, doubtsCleared;
    private Rigidbody2D targBody;
    public Vector2 Target { get { return targBody.position; } }

    public void Init(float n, float a)
    {
        noticeRange = MakeRangeCollider(nameof(noticeRange), n);
        attackRange = MakeRangeCollider(nameof(attackRange), a);
        canAttack = true;
    }

    public bool PlayerPresence()
    {

        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, noticeRange.radius, Vector2.zero);
        foreach (RaycastHit2D hit in hits)
        {
            if (hit.collider.TryGetComponent<CharacterMovement>(out _))
            {
                return true;
            }
        }
        return false;
    }

    private CircleCollider2D MakeRangeCollider(string name, float radius)
    {
        CircleCollider2D collider = new GameObject(name).AddComponent<CircleCollider2D>();
        collider.transform.SetParent(transform, false);
        collider.transform.localPosition = Vector3.zero;
        collider.isTrigger = true;
        collider.radius = radius;
        return collider;
    }
    public void StartDoubtTimer()
    {
        Invoke(nameof(ClearDoubt), suspicionTimer);
    }

    private void ClearDoubt()
    {
        doubtsCleared?.Invoke();
        aggro = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.TryGetComponent<CharacterCheckpointer>(out _))
        {
            return;
        }

        if (aggro)
        {
            if (other.IsTouching(attackRange))
            {
                TryAttack();
            }
            return;
        }
        if (other.IsTouching(noticeRange))
        {
            StartAggro(other.attachedRigidbody);
        }
    }

    private void StartAggro(Rigidbody2D rb)
    {
        targBody = rb;
        aggro = true;
        onAggroStart?.Invoke();
    }

    private void TryAttack()
    {
        if (canAttack)
        {
            attackAttempt?.Invoke();
            StartRecovery();
        }
    }

    public void StartRecovery()
    {
        canAttack = false;
        Invoke(nameof(Recover), attackCD);
    }

    private void Recover()
    {
        canAttack = true;
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, attackRange.radius, Vector2.zero);
        foreach(RaycastHit2D hit in hits)
        {
            if (hit.collider.TryGetComponent<CharacterMovement>(out _))
            {
                TryAttack();
                break;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (!other.TryGetComponent<CharacterCheckpointer>(out _))
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

    public void StopAggro()
    {
        aggro = false;
        onAggroEnd?.Invoke();
    }
}

