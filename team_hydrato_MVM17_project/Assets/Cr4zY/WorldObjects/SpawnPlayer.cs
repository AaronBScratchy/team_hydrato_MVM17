using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{
    [SerializeField] PlayerInit playerPrefab;
    void Awake()
    {
        Instantiate(playerPrefab, transform.position, transform.rotation).Init();
        Destroy(gameObject);
    }
}
