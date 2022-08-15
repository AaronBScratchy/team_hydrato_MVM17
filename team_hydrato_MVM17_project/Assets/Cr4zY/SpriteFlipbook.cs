using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//A data structure for a queue of sprite animation frames
[CreateAssetMenu]
public class SpriteFlipbook : ScriptableObject
{
    [SerializeField] SpriteAnimationFrame[] frames;
    public SpriteAnimationFrame[] GetFrames()
    {
        return frames;
    }
}

//Struct containing sprite animation frame data
[Serializable]
public struct SpriteAnimationFrame
{
    public Sprite Sprite { get { return _sprite; } }
    public float Time { get { return _time; } }

    [SerializeField] Sprite _sprite;
    [SerializeField] float _time;
}