using UnityEngine;
[CreateAssetMenu]
public class BucklerOverride : AIStateMachineOverride
{
    public override void Init()
    {
        overrides = new();
        overrides.Add(AIState.AGGRO, CreateInstance<AI_2DAggro>());
        overrides.Add(AIState.ROAM, CreateInstance<AI_Flying>());
        overrides.Add(AIState.ATTACK, CreateInstance<AI_BucklerAttack>());
        overrides.Add(AIState.HURT, CreateInstance<AI_FlyingHurt>());
        overrides.Add(AIState.IDLE, overrides[AIState.ROAM]);

    }
}

