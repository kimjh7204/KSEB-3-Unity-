using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    
    public AudioData[] soundResources;
    private Dictionary<string, AudioClip> soundDB = new();

    public int poolSize;
    public GameObject soundNodePrefab;
    private Queue<AudioNode> soundPool = new();
    
    void Awake()
    {
        instance = this;
        
        foreach (var soundResource in soundResources)
        {
            soundDB.Add(soundResource.key, soundResource.Clip); 
        }
        
        DontDestroyOnLoad(gameObject);

        for (int i = 0; i < poolSize; i++)
        {
            MakeNode();
        }
    }

    private void MakeNode()
    {
        var audioNode = Instantiate(soundNodePrefab, transform).GetComponent<AudioNode>();
        soundPool.Enqueue(audioNode);
    }

    public void PlaySound(string key, Vector3 pos)
    {
        var node = GetNode();
        node.transform.position = pos;
        node.Play(soundDB[key]);
    }
    
    private AudioNode GetNode()
    {
        if (soundPool.Count < 1)
        {
            MakeNode();
        }

        var node = soundPool.Dequeue();
        //
        return node;
    }

    public void SetNode(AudioNode node)
    {
        soundPool.Enqueue(node);
    }
    
}

[Serializable]
public class AudioData
{
    public string key;
    public AudioClip Clip;
}
