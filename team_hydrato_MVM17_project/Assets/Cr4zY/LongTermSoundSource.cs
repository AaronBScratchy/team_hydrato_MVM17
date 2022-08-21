using System.Collections;
using System.Collections.Generic;
using FMODUnity;
using UnityEngine;

public class LongTermSoundSource : MonoBehaviour
{
    [SerializeField] EventReference SoundEvent;
    [SerializeField] bool PlayOnAwake;
    private FMOD.Studio.EventInstance inst;
    private void Awake()
    {
        inst = RuntimeManager.CreateInstance(SoundEvent);
        if (PlayOnAwake)
        {
            PlaySound();
        }
    }

    public void PlaySound()
    {

        inst.start();

    }

    public void EndSound()
    {
        if (inst.handle != null)
        {
            inst.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        }
    }

}
