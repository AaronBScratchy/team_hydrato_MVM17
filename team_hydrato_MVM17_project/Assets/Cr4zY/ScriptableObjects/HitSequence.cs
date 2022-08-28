using System;
using UnityEngine;

[CreateAssetMenu]
public class HitSequence : ScriptableObject
{
    [SerializeField] private HitScanData[] data;

    public HitScanData[] Data { get => data; }
}

[Serializable]
public struct HitScanData
{
    [SerializeField] private Vector2 size;
    [SerializeField] private Vector2 offset;
    [SerializeField] private float duration;
    [SerializeField] private float waitTime;
    [SerializeField] private bool local;

    public Vector2 Size { get => size; }
    public float Duration { get => duration; }
    public float WaitTime { get => waitTime; }
    public bool Local { get => local; }
    public Vector2 Offset { get => offset; }
}