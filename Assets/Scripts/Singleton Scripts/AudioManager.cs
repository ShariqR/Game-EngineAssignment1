using System.Diagnostics;
using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{
    public AudioSource sfx;

    //plays the sfx - if there is no audio source, returns null
    public void PlaySFX(AudioClip clip)
    {
        if (sfx == null)
        {
            UnityEngine.Debug.Log("No Audio Source");
            return;
        }
        sfx.PlayOneShot(clip);
    }

}