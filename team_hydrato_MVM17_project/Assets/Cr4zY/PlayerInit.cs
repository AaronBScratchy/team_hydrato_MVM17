using UnityEngine;

public class PlayerInit : MonoBehaviour
{
    public void Init()
    {
        PIA inputActions = new();
        inputActions.World.Jump.Enable();
        inputActions.World.Horizontal.Enable();

        inputActions.World.Exit.Enable();

        PlayerAnimation anim = GetComponent<PlayerAnimation>();
        PlayerMovement moves = GetComponent<PlayerMovement>();
        PlayerStateMachine states = GetComponent<PlayerStateMachine>();
        PlayerCamera camera = GetComponent<PlayerCamera>();

        anim.Init();
        moves.Init(inputActions);
        states.Init(anim,moves,inputActions);
        camera.Init(transform);

        inputActions.World.Exit.performed += camera.QuitGame;

        Destroy(this);
    }

}
