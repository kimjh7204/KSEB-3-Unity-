using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class SaveData
{
    private string fileName;
    private string directory;

    public SaveData(string _fileName, string _directory)
    {
        fileName = _fileName;
        directory = _directory;
    }
    
    public string GetFullPath() => GetDirectory() + "/" + fileName + ".json";
    public string GetDirectory() => Application.persistentDataPath + "/" + directory;
}

public class TestData : SaveData
{
    public int stage;
    public int playerID;
    public Vector3 playerPos;
    public EnemyData[] enemies;

    public TestData(string _fileName, string _directory) : base(_fileName, _directory)
    {
        
    }
    
    [Serializable]
    public class EnemyData
    {
        public Vector3 pos;
        public float hp;
        public int id;
    }
}