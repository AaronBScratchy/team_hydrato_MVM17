using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CirclularEnclosureBound : MonoBehaviour
{
    [SerializeField] private float innerRadius = 4;
    [SerializeField] private float thickness = .5f;
    [Range(3, 20)]
    [SerializeField] private int segments = 6;
    [SerializeField] private Vector2 scaler = Vector2.one;
    private void Awake()
    {
        EdgeCollider2D edge = GetComponent<EdgeCollider2D>();
        edge.isTrigger = true;

        edge.edgeRadius = thickness;
        float r = innerRadius + thickness;

        Vector2[] points = new Vector2[segments + 1];
        for (int i = 0; i < segments; i++)
        {
            points[i] = new(r * scaler.x * Mathf.Sin(2f * Mathf.PI * i / segments), r * scaler.y * Mathf.Cos(2f * Mathf.PI * i / segments));
        }
        points[^1] = points[0];

        edge.SetPoints(new(points));

    }

}
