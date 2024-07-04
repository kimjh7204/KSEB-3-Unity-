using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioData[] soundResources;
    private Dictionary<string, AudioClip> soundDB = new();
    
    void Awake()
    {
        foreach (var soundResource in soundResources)
        {
            soundDB.Add(soundResource.key, soundResource.Clip); 
        }
        
        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        
    }
}

[Serializable]
public class AudioData
{
    public string key;
    public AudioClip Clip;
}
