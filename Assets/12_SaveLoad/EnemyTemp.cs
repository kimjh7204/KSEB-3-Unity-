using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyTemp : MonoBehaviour
{
    public int id;
    public float hp;

    private void Start()
    {
        hp = Random.Range(0f, 100f);
    }

    public TestData.EnemyData GetEnemyData()
    {
        // var data = new TestData.EnemyData();
        //
        // data.id = id;
        // data.hp = hp;
        // data.pos = transform.position;
        //
        // return data;
        return new TestData.EnemyData
        {
            id = id,
            hp = hp,
            pos = transform.position
        };
    }
    
    //
    
    //
    
    //
}
