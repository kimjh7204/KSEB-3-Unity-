using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimulationManager : MonoBehaviour
{
    public static SimulationManager instance;

    public GameObject foodPrefab;

    public float foodRate;

    private float foodTimer;
    public float mapSize = 23f;

    private WaitForSeconds foodTime;
    
    void Awake()
    {
        instance = this;
        foodTime = new WaitForSeconds(foodRate);
        
        StartCoroutine(SpawningFood());
    }
    
    private IEnumerator SpawningFood()
    {
        while (true)
        {
            yield return foodTime;

            var posX = Random.Range(-mapSize, mapSize);
            var posY = Random.Range(-mapSize, mapSize);

            var foodPos = new Vector3(posX, 0f, posY);
            Instantiate(foodPrefab, foodPos, Quaternion.identity);
        }
    }
}
