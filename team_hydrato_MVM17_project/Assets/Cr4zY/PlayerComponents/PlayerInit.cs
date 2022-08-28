using UnityEngine;

public class PlayerInit : MonoBehaviour
{

    public void Init()
    {

        CharacterStatsData data = Resources.Load<CharacterStats>("Player Stats").GetStats(Character.BrokenHorn);

        PIA inputActions = new();
        inputActions.World.Enable();

        CharacterMovement moves = GetComponent<CharacterMovement>();
        CharacterStateMachine states = GetComponent<CharacterStateMachine>();
        CharacterCheckpointer checkPoint = GetComponent<CharacterCheckpointer>();
        CharacterSelect selector = GetComponent<CharacterSelect>();
        CustomAnimationController anim = GetComponent<CustomAnimationController>();
        PlayerCamera cam = GetComponent<PlayerCamera>();

        moves.Init(inputActions);
        moves.LoadStats(data);
        checkPoint.Init(moves);
        selector.Init(inputActions);
        anim.Init(GetComponent<SpriteRenderer>());
        states.Init(anim,moves,selector,inputActions);
        cam.Init();

        checkPoint.onDeath += states.Respawn;
        checkPoint.onDeath += moves.Respawn;

        Destroy(this);
    }

}
