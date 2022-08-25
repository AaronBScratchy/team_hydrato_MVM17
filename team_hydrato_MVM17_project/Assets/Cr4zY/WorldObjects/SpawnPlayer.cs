using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{
    [SerializeField] PlayerInit playerPrefab;
    public void Awake()
    {
        Instantiate(playerPrefab, transform.position, transform.rotation).Init();
    }
}
