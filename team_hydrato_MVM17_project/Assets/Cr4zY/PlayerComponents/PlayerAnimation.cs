using System;
using FMOD;
using FMODUnity;
using System.Collections.Generic;
using UnityEngine;

//Class to control playing animation clips, utilises monobehaviour invoke calls to update sprite
public class PlayerAnimation : MonoBehaviour
{
    //Queue of frames
    private Queue<SpriteAnimationFrame> playedSprites = new();
    private Queue<SpriteAnimationFrame> waitingSprites;
    private Queue<SoundEvent> playedSounds = new();
    private Queue<SoundEvent> queuedSounds;

    bool looping;
    bool playing;
    bool muted;

    public Action animOver;

    private SpriteRenderer SR;
    private SpriteAnimationFrame currentFrame;

    //Get reference to the sprite renderer
    public void Init()
    {
        SR = GetComponent<SpriteRenderer>();
    }

    //Start play animation
    public void PlayAnimation(AnimationClip clip, bool loop)
    {
        //End currently playing animation
        if (playing)
        {
            CancelInvoke();
            playedSprites.Clear();
            playedSounds.Clear();
        }

        looping = loop;
        muted = clip.Muted;

        //queue frames from chosen clip
        waitingSprites = new(clip.GetSprites().GetFrames());

        //Get first frame
        currentFrame = waitingSprites.Dequeue();

        //Update sprite
        UpdateDisplay();

        playing = true;

        //Invoke next frame call
        Invoke(nameof(FrameShift), currentFrame.Time);
        if (muted)
        {
            return;
        }

        queuedSounds = new(clip.GetSound().Events);
        Invoke(nameof(SoundForward), queuedSounds.Peek().Time);
    }

    public void SoundForward()
    {
        if (muted)
        {
            return;
        }

        RuntimeManager.PlayOneShot(queuedSounds.Peek().Event);

        playedSounds.Enqueue(queuedSounds.Dequeue());

        if (queuedSounds.Count == 0)
        {
            return;
        }
        Invoke(nameof(SoundForward), queuedSounds.Peek().Time);
    }

    //Flips the sprite
    public void Flip()
    {
        SR.flipX = !SR.flipX;
    }

    //Sets the sprite to a certain reflection
    public void SetFlip(bool flip)
    {
        SR.flipX = flip;
    }

    //Update current sprite
    private void UpdateDisplay()
    {
        SR.sprite = currentFrame.Sprite;
    }

    //Shift to next frame
    private void FrameShift()
    {
        //keep track of played frames here, for case of looping back on animation
        playedSprites.Enqueue(currentFrame);

        if (waitingSprites.Count == 0)
        {
            if (looping)
            {
                RestartCurrentAnimation();
                return;
            }

            playing = false;
            animOver?.Invoke();
            return;
        }
        currentFrame = waitingSprites.Dequeue();
        UpdateDisplay();
        Invoke(nameof(FrameShift), currentFrame.Time);
    }

    //Play animation from beginning
    private void RestartCurrentAnimation()
    {
        //skip to the end of current animation
        while (waitingSprites.Count > 0)
        {
            playedSprites.Enqueue(waitingSprites.Dequeue());
        }

        //queue all frames and clear played frames
        waitingSprites = new(playedSprites);
        playedSprites.Clear();

        //Get first frame and start animation
        currentFrame = waitingSprites.Dequeue();
        UpdateDisplay();

        Invoke(nameof(FrameShift), currentFrame.Time);
        if (muted)
        {
            return;
        }
        while (queuedSounds.Count > 0)
        {
            playedSounds.Enqueue(queuedSounds.Dequeue());
        }
        queuedSounds = new(playedSounds);
        playedSounds.Clear();

        Invoke(nameof(SoundForward), queuedSounds.Peek().Time);

    }
}
