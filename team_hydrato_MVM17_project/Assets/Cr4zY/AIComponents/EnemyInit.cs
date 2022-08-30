using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyType
{
    StarWarden,
    WingedBuckler
}
public class EnemyInit : MonoBehaviour
{
    [SerializeField] private float attackRange, noticeRange;
    [SerializeField] private EnemyType type;
    void Awake()
    {
        AIHurtBehaviour hurt = GetComponent<AIHurtBehaviour>();
        AIDetector detector = GetComponent<AIDetector>();
        AINavigator nav = GetComponent<AINavigator>();
        AIStateMachine stateMachine = GetComponent<AIStateMachine>();
        CustomAnimationController animator = GetComponent<CustomAnimationController>();

        animator.Init(GetComponent<SpriteRenderer>());
        detector.Init(noticeRange, attackRange);
        nav.Init();
        stateMachine.Init(detector, hurt, nav, animator, type.ToString());

        Destroy(this);
    }

}
