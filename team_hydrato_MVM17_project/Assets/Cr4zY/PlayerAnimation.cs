using System;
using System.Collections.Generic;
using UnityEngine;

//Class to control playing animation clips, utilises monobehaviour invoke calls to update sprite
public class PlayerAnimation : MonoBehaviour
{
    //Queue of frames
    private Queue<SpriteAnimationFrame> played = new();
    private Queue<SpriteAnimationFrame> notYet;

    bool looping;
    bool playing;
    public Action animOver;

    private SpriteRenderer SR;
    private SpriteAnimationFrame currentFrame;
    
    //Get reference to the sprite renderer
    public void Init()
    {
        SR = GetComponent<SpriteRenderer>();
    }

    //Start play animation
    public void PlayAnimation(SpriteAnimationClip clip, bool loop)
    {
        //End currently playing animation
        if (playing)
        {
            CancelInvoke();
            played.Clear();
        }

        looping = loop;

        //queue frames from chosen clip
        notYet = new(clip.GetFrames());

        //Get first frame
        currentFrame = notYet.Dequeue();

        //Update sprite
        UpdateDisplay();

        playing = true;

        //Invoke next frame call
        Invoke(nameof(FrameShift), currentFrame.Time);
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

    //Play animation from beginning
    private void RestartCurrentAnimation()
    {
        //skip to the end of current animation
        while (notYet.Count > 0)
        {
            played.Enqueue(notYet.Dequeue());
        }

        //queue all frames and clear played frames
        notYet = new(played);
        played.Clear();

        //Get first frame and start animation
        currentFrame = notYet.Dequeue();
        UpdateDisplay();

        Invoke(nameof(FrameShift), currentFrame.Time);
    }
}
