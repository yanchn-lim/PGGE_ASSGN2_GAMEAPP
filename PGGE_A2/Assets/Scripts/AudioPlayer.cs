using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PGGE.Patterns;

public class AudioPlayer : Singleton<AudioPlayer>
{
    //audio player inherits from the singleton pattern
    //so there can only be one audioplayer in the game

    //chose to do this because it can persist across the scenes
    //preventing the audio from being cutout when the scene changes

    AudioSource source;
    public AudioClip[] click;

    // Start is called before the first frame update
    void Start()
    {
        //get reference to the audiosource component attached to it
        source = GetComponent<AudioSource>();
    }

    //uses PlayOneShot() to only play the sound once
    public void PlayClickSound(int i)
    {
        source.PlayOneShot(click[i]);
    }
}
