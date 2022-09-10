using UnityEngine;
using System.Collections.Generic;

public abstract class AIStateMachineOverride : ScriptableObject
{
    protected Dictionary<AIState, AbstractAIState> overrides;

    public Dictionary<AIState, AbstractAIState> Overrides { get => overrides; }

    public abstract void Init();
}