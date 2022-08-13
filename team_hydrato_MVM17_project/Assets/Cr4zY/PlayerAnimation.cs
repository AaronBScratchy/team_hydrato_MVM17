using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Queue<SO_AnimationFrame> played = new();
    private Queue<SO_AnimationFrame> notYet;
    bool looping;
    bool playing;
    public Action animOver;

    private SpriteRenderer SR;
    private SO_AnimationFrame currentFrame;
    public void Init()
    {
        SR = GetComponent<SpriteRenderer>();
    }

    public void PlayAnimation(SO_AnimationClip clip, bool loop)
    {
        if (playing)
        {
            CancelInvoke();
            played.Clear();
        }
        looping = loop;
        notYet = new(clip.GetFrames());
        currentFrame = notYet.Dequeue();
        UpdateDisplay();
        playing = true;
        Invoke(nameof(FrameShift), currentFrame.Time);
    }

    public void Flip()
    {
        SR.flipX = !SR.flipX;
    }

    public void SetFlip(bool flip)
    {
        SR.flipX = flip;
    }

    private void UpdateDisplay()
    {
        SR.sprite = currentFrame.Sprite;
    }

    private void FrameShift()
    {
        played.Enqueue(currentFrame);

        if (notYet.Count == 0)
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
        currentFrame = notYet.Dequeue();
        UpdateDisplay();
        Invoke(nameof(FrameShift), currentFrame.Time);
    }

    private void RestartCurrentAnimation()
    {
        while (notYet.Count > 0)
        {
            played.Enqueue(notYet.Dequeue());
        }

        notYet = new(played);
        played.Clear();

        currentFrame = notYet.Dequeue();
        UpdateDisplay();

        Invoke(nameof(FrameShift), currentFrame.Time);
    }
}
