using UnityEngine;

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

        PlayerAnimation anim = GetComponent<PlayerAnimation>();
        PlayerMovement moves = GetComponent<PlayerMovement>();
        PlayerStateMachine states = GetComponent<PlayerStateMachine>();
        PlayerCamera camera = GetComponent<PlayerCamera>();
        PlayerCharacterSelector characterSelector = GetComponent<PlayerCharacterSelector>();

        anim.Init();
        moves.Init(inputActions);
        characterSelector.Init();
        states.Init(anim,moves,characterSelector,inputActions);
        camera.Init(transform);

        inputActions.World.Exit.performed += camera.QuitGame;

        Destroy(this);
    }

}
