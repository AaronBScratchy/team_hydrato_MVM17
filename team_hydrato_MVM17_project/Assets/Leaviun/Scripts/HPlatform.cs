using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPlatform : MonoBehaviour
{
    public List<Transform> points;
    public Transform platform;
    private Vector2 endPosition = new Vector2(5, 0);
    private Vector2 startPosition;
    private float desiredDuration = 3f;
    private float elapsedTime;

    [SerializeField]
    private AnimationCurve curve;

    void Start()
    {
        startPosition = Vector2.zero;
    }


    void Update()
    {
        elapsedTime += Time.deltaTime;
        float percentageComplete = elapsedTime / desiredDuration;

        platform.localPosition = Vector2.Lerp(startPosition, endPosition, curve.Evaluate(percentageComplete));
    }
}