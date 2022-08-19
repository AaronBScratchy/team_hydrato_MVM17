using UnityEngine;
public class PlayerCharacterSelector : MonoBehaviour 
{

    private Character current;

    public string CharacterName { get { return nameof(current); } }

    [SerializeField] private PlayerStats stats;

    public void Init()
    {
        current = Character.BrokenHorn;
    }

    public void Switch(bool forth)
    {
        current = current switch
        {
            Character.BrokenHorn => forth ? Character.II : Character.II,
            Character.II => forth ? Character.BrokenHorn : Character.BrokenHorn,
            Character.III => Character.BrokenHorn,
            Character.IV => Character.BrokenHorn,
            _ => Character.BrokenHorn
        };
    }

    public PlayerStatsData GetCurrentStats()
    {
        return stats.GetStats(current);
    }

}
