using System;
using UnityEngine;

[CreateAssetMenu]
public class CharacterStats : ScriptableObject
{
    [SerializeField] private CharacterStatsData[] stats;

    public CharacterStatsData GetStats(int index)
    {
        return stats[index];
    }

    public CharacterStatsData GetStats(Character charac)
    {
        return stats[charac switch
        {
            Character.BrokenHorn => 0,
            Character.Scythe => 1,
            Character.III => 2,
            Character.IV => 3,
            _ => 0
        }];
    }

}

[Serializable]
public struct CharacterStatsData
{
    [SerializeField] private Character character;

    public float maxSpeed;
    public float acceleration;
    public float maxAirSpeed;
    public float airAcceleration;
    public float minJumpForce;
    public float maxJumpForce;
    public float wallJumpForce;
    public float wallSlideSpeed;
    public float gravityScale;


}

public enum Character
{
    None,
    BrokenHorn,
    Scythe,
    III,
    IV,
}

