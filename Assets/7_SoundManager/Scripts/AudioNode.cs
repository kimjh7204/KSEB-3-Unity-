using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioNode : MonoBehaviour
{
    [SerializeField]
    private AudioSource audioSource;

    public void Play(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }
    
}
