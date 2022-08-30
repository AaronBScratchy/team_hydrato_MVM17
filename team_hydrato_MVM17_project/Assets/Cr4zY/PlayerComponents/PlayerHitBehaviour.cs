using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitBehaviour : MonoBehaviour
{
    public void StartHitScan(Vector2 size, Vector2 origin, float duration)
    {
        StartCoroutine(HitScan(size, origin, duration));
    }

    public void StartHitScan(Vector2 size, Rigidbody2D localBody, float duration, float localOffsetX = 0, float localOffsetY = 0)
    {
        Vector2 localOffset = new(localOffsetX, localOffsetY);
        StartCoroutine(HitScan(size, localBody, localOffset, duration));
    }

    private IEnumerator HitScan(Vector2 size, Rigidbody2D localBody, Vector2 localOffset, float duration)
    {
        List<IHittable> hits = new();
        while (duration > 0)
        {
            foreach (RaycastHit2D hit in Physics2D.BoxCastAll(localBody.position + localOffset, size, 0, Vector2.zero))
            {
                IHittable target = hit.collider.GetComponent<IHittable>();
                if (target == null)
                {
                    continue;
                }
                if (hits.Contains(target))
                {
                    continue;
                }
                target.OnHit(this);
                hits.Add(target);
            }

            yield return null;

            duration -= Time.deltaTime;
        }
    }

    private IEnumerator HitScan(Vector2 size, Vector2 origin, float duration)
    {

        while (duration > 0)
        {
            foreach (RaycastHit2D hit in Physics2D.BoxCastAll(origin, size, 0, Vector2.zero))
            {
                IHittable target = hit.collider.GetComponent<IHittable>();
                if (target != null)
                {
                    target.OnHit(this);
                }
            }

            yield return null;

            duration -= Time.deltaTime;
        }

    }

}

