using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Things that can be hit by the player
public interface IHittable
{
    public abstract void OnHit(PlayerHitBehaviour player);
}
