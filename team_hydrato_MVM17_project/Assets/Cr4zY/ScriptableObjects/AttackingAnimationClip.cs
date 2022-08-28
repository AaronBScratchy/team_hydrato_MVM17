using System;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class AttackingAnimationClip : AnimationClip
{
    [SerializeField] private HitSequence hits;
    [SerializeField] private AnimationCancelWindow window;
    [SerializeField] private bool cancellable;

    public bool Cancellable { get => cancellable; set => cancellable = value; }

    public HitSequence GetHits()
    {
        return hits;
    }

    public AnimationCancelWindow GetWindow()
    {
        return window;
    }

}

[Serializable]
public struct AnimationCancelWindow
{
    [SerializeField] private float start, end, bufferTime;

    public float Start { get => start; }
    public float End { get => end; }
    public float BufferTime { get => bufferTime; }
}