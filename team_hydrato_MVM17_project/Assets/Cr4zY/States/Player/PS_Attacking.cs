using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PS_Attacking : AbstractUpdatingPS
{
    private AttackingAnimationClip[] attackClips;
    private int index;
    private bool inCancelWindow, inBufferWindow;
    private Action bufferCall;
    private float bufferTimer, cancelTimer, resetTimer;

    public override void Init(CustomAnimationController _a, CharacterMovement _m, CharacterStateMachine _s, CharacterSelect _c, PlayerHurtBehaviour _h)
    {
        base.Init(_a, _m, _s, _c, _h);
        inCancelWindow = false;
        inBufferWindow = false;
        index = -1;
    }
    public override void OnStateEnter(PIA actions)
    {
        movement.RestRB();
        movement.falling += Fall;

        hurtBehaviour.hurt += GetHurt;

        if (index < 0)
        {
            stateMachine.onUpdate += OnUpdate;
        }

        PerformNextAttack();

        actions.World.Attack.performed += OnAttackInState;
    }

    private void GetHurt()
    {
        OnExit?.Invoke(State.Hurt);
    }

    private void OnAttackInState(InputAction.CallbackContext obj)
    {
        if (inCancelWindow)
        {
            PerformNextAttack();
            return;
        }
        if (inBufferWindow)
        {
            BufferAttack();
            return;
        }

    }

    public override void OnStateExit(PIA actions)
    {
        movement.falling -= Fall;

        hurtBehaviour.hurt -= GetHurt;
        actions.World.Attack.performed -= OnAttackInState;
    }

    private void BufferAttack()
    {

        if (!inBufferWindow)
        {
            return;
        }

        bufferCall += PerformNextAttack;

    }

    private void PerformNextAttack()
    {
        inBufferWindow = false;
        inCancelWindow = false;

        index++;
        anim.PlayAttackAnimation(attackClips[index], false);
        Debug.Log(attackClips[index].name);
        AnimationCancelWindow cancelWindow = attackClips[index].GetWindow();
        movement.Launch(movement.FindRelativeToMe(Vector2.right*(movement.FacingPosX?-1:1)),4);

        anim.animOver += EndAttack;

        if (!attackClips[index].Cancellable)
        {
            return;
        }


        bufferTimer = cancelWindow.Start - cancelWindow.BufferTime;
        cancelTimer = bufferTimer > 0 ? cancelWindow.BufferTime : cancelWindow.Start;
        resetTimer = cancelWindow.End - cancelWindow.Start;
        inBufferWindow = !(bufferTimer > 0);
    }

    private void EndAttack()
    {
        anim.animOver -= EndAttack;
        OnExit?.Invoke(movement.ResolveGroundState());
        if (inCancelWindow)
        {
            return;
        }
        index = -1;
        stateMachine.onUpdate -= OnUpdate;
    }



    public override void BindStateAnimation(string currentChar)
    {
        attackClips = Resources.LoadAll<AttackingAnimationClip>("AnimationClips/Player/Attacks/" + currentChar);
    }


    protected override void OnUpdate()
    {
        if (!attackClips[index].Cancellable)
        {
            return;
        }
        if (inCancelWindow)
        {
            resetTimer -= Time.deltaTime;
            if (resetTimer > 0)
            {
                return;
            }
            inCancelWindow = false;
            stateMachine.onUpdate -= OnUpdate;
            index = -1;

            return;
        }
        if (inBufferWindow)
        {
            cancelTimer -= Time.deltaTime;
            if (cancelTimer > 0)
            {
                return;
            }
            inBufferWindow = false;
            inCancelWindow = true;
            bufferCall?.Invoke();
            bufferCall = null;
            return;
        }
        bufferTimer -= Time.deltaTime;
        if (bufferTimer > 0)
        {
            return;
        }
        inBufferWindow = true;

    }

    protected override void OnFixedUpdate()
    {
    }

    private void Fall()
    {
        OnExit?.Invoke(State.Falling);
    }
}
