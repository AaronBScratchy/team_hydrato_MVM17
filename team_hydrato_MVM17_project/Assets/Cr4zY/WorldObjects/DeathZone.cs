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

        if (collision.TryGetComponent<CharacterCheckpointer>(out CharacterCheckpointer player))
        {
            player.onDeath?.Invoke();
            return;
        }

        Destroy(collision.gameObject);
    }
}

