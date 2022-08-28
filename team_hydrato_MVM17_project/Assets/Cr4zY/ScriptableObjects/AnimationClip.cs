using System;
using UnityEngine;

[CreateAssetMenu]
public class AnimationClip : ScriptableObject
{
    [SerializeField] protected SoundEventTrack sound;
    [SerializeField] protected SpriteFlipbook flipbook;
    [SerializeField] protected bool m_muted;
    public bool Muted { get { return m_muted; } private set { m_muted = value; } }

    public SoundEventTrack GetSound()
    {
        return sound;
    }

    public SpriteFlipbook GetSprites()
    {
        return flipbook;
    }

}
