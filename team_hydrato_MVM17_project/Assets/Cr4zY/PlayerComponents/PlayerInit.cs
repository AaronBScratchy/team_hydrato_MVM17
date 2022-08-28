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
        PlayerHurtBehaviour hurt = GetComponent<PlayerHurtBehaviour>();

        moves.Init(inputActions);
        moves.LoadStats(data);
        checkPoint.Init(moves);
        selector.Init(inputActions);
        anim.Init(GetComponent<SpriteRenderer>());
        hurt.Init();
        states.Init(anim, moves, selector, hurt, inputActions);
        cam.Init();

        checkPoint.onDeath += states.Respawn;
        checkPoint.onDeath += moves.Respawn;

        Destroy(this);
    }

}
