using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SimulationManager : MonoBehaviour
{
    public static SimulationManager instance;

    public GameObject foodPrefab;
    public int initialFoodAmount;
    public float foodRate;
    private float foodTimer;
    private WaitForSeconds foodTime;

    public GameObject DovePrefab;
    public GameObject HawkPrefab;
    public int initialDoveAmount;
    public int initialHawkAmount;
    
    [HideInInspector]
    public float mapSize = 23f;
    public Slider timeMultSlider;


    public TextMeshProUGUI timeScaleText;
    
    
    void Awake()
    {
        instance = this;
        foodTime = new WaitForSeconds(foodRate);

        StartSimulation(); //JH - Button에 연결
    }

    private void Update()
    {
        Time.timeScale = timeMultSlider.value;
    }

    public void StartSimulation()
    {
        //Generate Initial Foods
        for (int i = 0; i < initialFoodAmount; i++)
        {
            SpawnPrefabRandomPos(foodPrefab);
        }
        
        //Generate initial Units
        for (int i = 0; i < initialDoveAmount; i++)
        {
            SpawnPrefabRandomPos(DovePrefab);
        }
        for (int i = 0; i < initialHawkAmount; i++)
        {
            SpawnPrefabRandomPos(HawkPrefab);
        }
        
        StartCoroutine(SpawningFood());
    }

    private void SpawnPrefabRandomPos(GameObject prefab)
    {
        var posX = Random.Range(-mapSize, mapSize);
        var posY = Random.Range(-mapSize, mapSize);

        var pos = new Vector3(posX, 0f, posY);
        Instantiate(prefab, pos, Quaternion.identity);
    }
    
    private IEnumerator SpawningFood()
    {
        while (true)
        {
            yield return foodTime;

            SpawnPrefabRandomPos(foodPrefab);
        }
    }

    public void SetTimeScaleText(float value)
    {
        timeScaleText.text = "x " + value.ToString("N2");
    }
}
