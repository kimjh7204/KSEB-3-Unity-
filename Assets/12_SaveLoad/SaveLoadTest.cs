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

    private GameObject[] enemies;
    private void Awake()
    {
        enemies = new GameObject[3];
        
        enemies[0] = Resources.Load<GameObject>("Enemy1");
        enemies[1] = Resources.Load<GameObject>("Enemy2");
        enemies[2] = Resources.Load<GameObject>("Enemy3");
    }

    public void GenerateData()
    {
        playerID.text = Random.Range(0, int.MaxValue).ToString();
        
        player.transform.position = GetRandomPos();
        
        var enemyCount = Random.Range(5, 11);

        for (int i = 0; i < enemyCount; i++)
        {
            var enemyID = Random.Range(0, enemies.Length);
            Instantiate(enemies[enemyID], GetRandomPos(), Quaternion.identity);
        }
    }

    private Vector3 GetRandomPos()
    {
        var pos = Random.insideUnitCircle * 5f;
        return new Vector3(pos.x, 0f, pos.y);
    }
}
