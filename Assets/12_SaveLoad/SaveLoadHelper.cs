using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public static class SaveLoadHelper
{
    public static void SaveData<T>(T data) where T : SaveData
    {
        if (!Directory.Exists(data.GetDirectory()))
        {
            Directory.CreateDirectory(data.GetDirectory());
        }
        
        var json = JsonUtility.ToJson(data);
        File.WriteAllText(data.GetFullPath(), json);

        Debug.Log("Data is Saved : " + data.GetFullPath());
    }

    public static T LoadData<T>(string fileName, string dir) where T : SaveData
    {
        var fullPath = Application.persistentDataPath + "/" + dir + "/" + fileName + ".json";

        if (!File.Exists(fullPath))
        {
            Debug.LogError("There is no file : " + fullPath);
            return null;
        }

        var json = File.ReadAllText(fullPath);
        var data = JsonUtility.FromJson<T>(json);

        Debug.Log("Data is Loaded : " + fullPath);
        
        return data;
    }
}
