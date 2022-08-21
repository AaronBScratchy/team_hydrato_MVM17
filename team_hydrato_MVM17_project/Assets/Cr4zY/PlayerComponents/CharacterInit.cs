using UnityEngine;

[RequireComponent(typeof(CustomAnimationController))]
[RequireComponent(typeof(CharacterMovement))]
[RequireComponent(typeof(CharacterStateMachine))]
[RequireComponent(typeof(CharacterCheckpointer))]

public class CharacterInit : MonoBehaviour
{

    [SerializeField] private Character character;
    public CharacterStateMachine Init(PIA actions)
    {
        CharacterStats stats = Resources.Load<CharacterStats>("Player Stats");
        CharacterStatsData data = stats.GetStats(character);

        PIA inputActions = actions;

        gameObject.SetActive(false);

        CustomAnimationController anim = GetComponent<CustomAnimationController>();
        CharacterMovement moves = GetComponent<CharacterMovement>();
        CharacterStateMachine states = GetComponent<CharacterStateMachine>();
        CharacterCheckpointer checkPoint = GetComponent<CharacterCheckpointer>();

        anim.Init();
        moves.Init(inputActions);
        moves.LoadStats(data);
        checkPoint.Init(moves);
        states.Init(anim,moves,character,inputActions);

        checkPoint.onDeath += states.Respawn;
        checkPoint.onDeath += moves.Respawn;

        return states;
    }

}
