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
        StartCoroutine(WaitSound());
    }


    private IEnumerator WaitSound()
    {
        yield return new WaitWhile(() => audioSource.isPlaying);
        //yield return new WaitWhile(IsPlaying);
        
        SoundManager.instance.SetNode(this);
    }

    // private bool IsPlaying()
    // {
    //     return audioSource.isPlaying;
    // }
    //
    // private bool IsPlaying2() => audioSource.isPlaying;
}
