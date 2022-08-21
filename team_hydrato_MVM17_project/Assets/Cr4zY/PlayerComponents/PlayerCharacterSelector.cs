using UnityEngine;
public class PlayerCharacterSelector : MonoBehaviour 
{

    private Character current;

    public string CharacterName { get { return current.ToString(); } }

    [SerializeField] private CharacterStats stats;

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

    public CharacterStatsData GetCurrentStats()
    {
        return stats.GetStats(current);
    }

}
