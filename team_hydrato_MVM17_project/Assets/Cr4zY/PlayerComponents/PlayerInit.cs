using UnityEngine;

[RequireComponent(typeof(CustomAnimationController))]
[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(PlayerStateMachine))]
[RequireComponent(typeof(PlayerCamera))]
[RequireComponent(typeof(PlayerCharacterSelector))]
[RequireComponent(typeof(PlayerCheckPointer))]

public class PlayerInit : MonoBehaviour
{
    public void Init()
    {
        PIA inputActions = new();
        inputActions.World.Jump.Enable();
        inputActions.World.Horizontal.Enable();
        inputActions.World.Crouch.Enable();
        inputActions.World.CharacterSwitchFwd.Enable();
        inputActions.World.CharacterSwitchBack.Enable();

        inputActions.World.Exit.Enable();

        CustomAnimationController anim = GetComponent<CustomAnimationController>();
        PlayerMovement moves = GetComponent<PlayerMovement>();
        PlayerStateMachine states = GetComponent<PlayerStateMachine>();
        PlayerCamera camera = GetComponent<PlayerCamera>();
        PlayerCharacterSelector characterSelector = GetComponent<PlayerCharacterSelector>();
        PlayerCheckPointer checkPoint = GetComponent<PlayerCheckPointer>();

        anim.Init();
        moves.Init(inputActions);
        characterSelector.Init();
        checkPoint.Init(moves);
        states.Init(anim,moves,characterSelector,inputActions);
        camera.Init(transform);

        checkPoint.onDeath += states.Respawn;
        checkPoint.onDeath += moves.Respawn;

        inputActions.World.Exit.performed += camera.QuitGame;

        Destroy(this);
    }

}
