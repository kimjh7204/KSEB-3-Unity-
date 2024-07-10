using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SaveData
{
    public string fileName;
    public string directory;

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
        //?
    }
    
    public class EnemyData
    {
        public Vector3 pos;
        public float hp;
        public int id;
    }
}