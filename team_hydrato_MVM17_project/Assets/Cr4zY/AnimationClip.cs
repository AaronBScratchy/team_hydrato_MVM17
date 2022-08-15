using System;
using UnityEngine;

[CreateAssetMenu]
public class AnimationClip : ScriptableObject
{
    [SerializeField] SoundEventTrack sound;
    [SerializeField] SpriteFlipbook flipbook;
    [SerializeField] bool m_muted;
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
