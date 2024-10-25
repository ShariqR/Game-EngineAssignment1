using System.Diagnostics;
using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{
    public AudioSource sfx;
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