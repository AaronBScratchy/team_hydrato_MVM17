using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private SpawnPlayer[] playerSpawns;

    private CharacterStateMachine[] characters;
    private PlayerCamera cam;

    private void Awake()
    {
        cam = GetComponent<PlayerCamera>();
        characters = new CharacterStateMachine[playerSpawns.Length];

        PIA actions = new();

        actions.World.Jump.Enable();
        actions.World.Horizontal.Enable();
        actions.World.Crouch.Enable();
        actions.World.CharacterSwitchFwd.Enable();
        actions.World.CharacterSwitchBack.Enable();

        actions.World.Exit.Enable();
        actions.World.Exit.performed+=cam.QuitGame;

        for (int i = 0; i < playerSpawns.Length; i++)
        {
            characters[i] = playerSpawns[i].Spawn(actions);
        }

        Possess(characters[0]);

        cam.Init();
    }

    private void Possess(Character character)
    {
        Possess(character switch
        {
            Character.BrokenHorn => characters[0],
            Character.II => characters[1],
            Character.III => characters[0],
            Character.IV => characters[0],
            _ => characters[0]
        });
    }

    private void Possess(CharacterStateMachine target)
    {
        target.onChangeWish += Possess;
        target.ResumeCurrentState();
        cam.Focus(target.transform);
    }
}
