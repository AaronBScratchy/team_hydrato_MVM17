using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SO_AnimationClip : ScriptableObject
{
    [SerializeField] SO_AnimationFrame[] frames;
    public SO_AnimationFrame[] GetFrames()
    {
        return frames;
    }
}

[Serializable]
public struct SO_AnimationFrame
{
    public Sprite Sprite { get { return _sprite; } }
    public float Time { get { return _time; } }

    [SerializeField] Sprite _sprite;
    [SerializeField] float _time;
}