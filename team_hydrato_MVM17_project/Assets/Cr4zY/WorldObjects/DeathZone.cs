using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class DeathZone : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<Collider2D>().isTrigger = true;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == null)
        {
            return;
        }

        if(collision.TryGetComponent<PlayerCheckPointer>(out PlayerCheckPointer player))
        {
            player.onDeath?.Invoke();
        }
    }
}

