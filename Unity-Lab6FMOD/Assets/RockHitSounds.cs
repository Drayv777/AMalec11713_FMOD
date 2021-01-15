using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockHitSounds : MonoBehaviour
{
    [SerializeField] AudioClip[] sounds;

    [SerializeField] AudioSource audiosource;

    public void PlayRandomSound()
    {
        int n = Random.Range(1, sounds.Length);
        audiosource.clip = sounds[n];
        audiosource.Play();
        // move picked sound to index 0 so it's not picked next time
        sounds[n] = sounds[0];
        sounds[0] = audiosource.clip;
    }
}
