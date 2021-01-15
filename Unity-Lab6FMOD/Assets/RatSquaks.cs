using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatSquaks : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip[] squeaks;

    public void PlayRandomSound()
    {
        int n = Random.Range(1, squeaks.Length);
        audioSource.clip = squeaks[n];
        audioSource.Play();
        // move picked sound to index 0 so it's not picked next time
        squeaks[n] = squeaks[0];
        squeaks[0] = audioSource.clip;
    }
}
