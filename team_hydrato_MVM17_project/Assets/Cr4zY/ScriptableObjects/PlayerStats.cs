using System;
using UnityEngine;

[CreateAssetMenu]
public class PlayerStats : ScriptableObject
{
    [SerializeField] private PlayerStatsData[] stats;

    public PlayerStatsData GetStats(int index)
    {
        return stats[index];
    }

    public PlayerStatsData GetStats(Character charac)
    {
        return stats[charac switch
        {
            Character.BrokenHorn => 0,
            Character.II => 1,
            Character.III => 2,
            Character.IV => 3,
            _ => 0
        }];
    }

}

[Serializable]
public struct PlayerStatsData
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
    BrokenHorn,
    II,
    III,
    IV
}

