using System.Collections;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    bool going;
    [SerializeField] private float minSpeed, maxSpeed;

    private Rigidbody2D rb;

    [SerializeField] private Vector2 secondPositionOffset;

    private void Awake()
    {
        going = true;
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(MovePlatform());
    }

    private void OnDestroy()
    {
        StopAllCoroutines();
    }

    private IEnumerator MovePlatform()
    {
        bool reached = false;
        Vector2 endPoint = rb.position + (going ? secondPositionOffset : -secondPositionOffset);
        Vector2 dirNorm = (endPoint - rb.position).normalized;
        rb.velocity = dirNorm * minSpeed;
        float alpha;
        float progress;
        while (!reached)
        {
            progress = (endPoint - rb.position).magnitude / secondPositionOffset.magnitude;
            alpha = Mathf.Sin(progress * Mathf.PI);
            rb.velocity = dirNorm * (Mathf.Lerp(minSpeed, maxSpeed, alpha));
            yield return null;
            reached = Vector2.Dot((endPoint - rb.position).normalized, dirNorm) < -0.975f;
        }

        rb.MovePosition(endPoint);

        going = !going;

        StartCoroutine(MovePlatform());
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent<PlayerMovement>(out PlayerMovement moves))
        {
            moves.SetLocalSpace(rb);
        }
    }

}
