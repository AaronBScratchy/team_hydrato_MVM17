using System;
using FMODUnity;
using UnityEngine;

[CreateAssetMenu]
public class SoundEventTrack : ScriptableObject
{

    [SerializeField] SoundEvent[] events;

    public SoundEvent[] Events { get { return events; } }

}

[Serializable]
public struct SoundEvent
{

    [SerializeField] EventReference _event;

    [SerializeField] float _time;

    public EventReference Event { get { return _event; } }
    public float Time { get { return _time; } }

}
