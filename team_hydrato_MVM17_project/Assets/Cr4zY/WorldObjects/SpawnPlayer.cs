using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{
    [SerializeField] CharacterInit playerPrefab;
    public CharacterStateMachine Spawn(PIA actions)
    {
        return Instantiate(playerPrefab, transform.position, transform.rotation).Init(actions);
    }
}
