using UnityEngine;
public abstract class AbstractAIState : ScriptableObject
{
    protected AIHurtBehaviour hurt;
    protected AIDetector detector;
    protected AIStateMachine stateMachine;
    protected AINavigator nav;
    public virtual void Init(AINavigator _n, AIStateMachine _s, AIDetector _d, AIHurtBehaviour _h)
    {
        hurt = _h;
        detector = _d;
        stateMachine = _s;
        nav = _n;

    }
    protected abstract void OnStateEnter();     

    protected abstract void OnStateExit();


}
