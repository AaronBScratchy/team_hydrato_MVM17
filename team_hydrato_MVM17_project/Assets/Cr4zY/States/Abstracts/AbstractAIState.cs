using UnityEngine;
public abstract class AbstractAIState : ScriptableObject
{
    protected abstract void OnStateEnter();     

    protected abstract void OnStateExit();


}
