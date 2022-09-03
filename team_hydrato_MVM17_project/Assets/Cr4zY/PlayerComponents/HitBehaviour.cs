using System.Collections;
using UnityEngine;

public abstract class HitBehaviour : MonoBehaviour
{
    public void StartHitScan(Vector2 size, Vector2 origin, float duration)
    {
        StartCoroutine(HitScan(size, origin, duration));
    }

    public void StartHitScan(Vector2 size, Rigidbody2D localBody, float duration, bool spriteFlip, float localOffsetX = 0, float localOffsetY = 0)
    {
        Vector2 localOffset = new(spriteFlip ? -localOffsetX : localOffsetX, localOffsetY);
        StartCoroutine(HitScan(size, localBody, localOffset, duration));    
    }

    protected abstract IEnumerator HitScan(Vector2 size, Rigidbody2D localBody, Vector2 localOffset, float duration);
    protected abstract IEnumerator HitScan(Vector2 size, Vector2 origin, float duration);
}