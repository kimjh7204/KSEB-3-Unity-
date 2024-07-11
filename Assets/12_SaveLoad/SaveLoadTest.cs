using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class SaveLoadTest : MonoBehaviour
{
    public TMP_InputField stage;
    public TMP_Text playerID;
    
    public GameObject player;

    private GameObject[] enemyPrefabs;

    private List<EnemyTemp> enemies = new List<EnemyTemp>();
    
    private void Awake()
    {
        enemyPrefabs = new GameObject[3];
        
        enemyPrefabs[0] = Resources.Load<GameObject>("Enemy1");
        enemyPrefabs[1] = Resources.Load<GameObject>("Enemy2");
        enemyPrefabs[2] = Resources.Load<GameObject>("Enemy3");
    }

    public void GenerateData()
    {
        playerID.text = Random.Range(0, int.MaxValue).ToString();
        
        player.transform.position = GetRandomPos();
        
        var enemyCount = Random.Range(5, 11);

        foreach (var enemyTemp in enemies)
        {
            Destroy(enemyTemp.gameObject);
        }
        enemies.Clear();
        
        for (int i = 0; i < enemyCount; i++)
        {
            var enemyID = Random.Range(0, enemyPrefabs.Length);
            var enemy = Instantiate(enemyPrefabs[enemyID], GetRandomPos(), Quaternion.identity).GetComponent<EnemyTemp>();
            
            enemies.Add(enemy);
        }
    }

    private Vector3 GetRandomPos()
    {
        var pos = Random.insideUnitCircle * 5f;
        return new Vector3(pos.x, 0f, pos.y);
    }

    public void SaveData()
    {
        var data = new TestData("GameData","Test/Bootcamp");

        data.stage = Convert.ToInt32(stage.text);
        data.playerID = Convert.ToInt32(playerID.text);
        data.playerPos = player.transform.position;

        var enemyData = new TestData.EnemyData[enemies.Count];

        for (int i = 0; i < enemies.Count; i++)
        {
            enemyData[i] = enemies[i].GetEnemyData();
        }

        data.enemies = enemyData;

        var json = JsonUtility.ToJson(data);
        Debug.Log(json);
    }
}
