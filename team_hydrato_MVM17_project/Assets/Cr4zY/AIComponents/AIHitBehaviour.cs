using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class AIHitBehaviour : HitBehaviour
{
    [SerializeField] private int DamagePerHit;
    [SerializeField] private bool launcher;
    [SerializeField] private float launchPower;
    protected override IEnumerator HitScan(Vector2 size, Rigidbody2D localBody, Vector2 localOffset, float duration)
    {
        while (duration > 0)
        {
            foreach (RaycastHit2D hit in Physics2D.BoxCastAll(localBody.position + localOffset, size, 0, Vector2.zero))
            {
                PlayerHurtBehaviour target = hit.collider.GetComponent<PlayerHurtBehaviour>();
                if (target == null)
                {
                    continue;
                }
                if (launcher)
                {
                    target.LaunchPlayer(localBody.position + Vector2.down, launchPower);
                }
                target.DamagePlayer(DamagePerHit);

                yield break;
            }

            yield return null;

            duration -= Time.deltaTime;
        }
    }

    protected override IEnumerator HitScan(Vector2 size, Vector2 origin, float duration)
    {

        while (duration > 0)
        {
            foreach (RaycastHit2D hit in Physics2D.BoxCastAll(origin, size, 0, Vector2.zero))
            {
                PlayerHurtBehaviour target = hit.collider.GetComponent<PlayerHurtBehaviour>();
                if (target == null)
                {
                    continue;
                }
                if (launcher)
                {
                    target.LaunchPlayer(origin, launchPower);
                }
                target.DamagePlayer(DamagePerHit);

                yield break;
            }

            yield return null;

            duration -= Time.deltaTime;
        }

    }
}

