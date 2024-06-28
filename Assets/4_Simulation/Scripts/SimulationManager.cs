using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SimulationManager : MonoBehaviour
{
    public static SimulationManager instance;

    [Header("-Food")]
    public GameObject foodPrefab;
    public int initialFoodAmount;
    public float foodRate;
    public TextMeshProUGUI foodAmountText;
    private float foodTimer;
    private WaitForSeconds foodTime;
    [Header("-Dove")]
    public GameObject DovePrefab;
    public int initialDoveAmount;
    public TextMeshProUGUI doveAmountText;
    [Header("-Hawk")]
    public GameObject HawkPrefab;
    public int initialHawkAmount;
    public TextMeshProUGUI hawkAmountText;

    [Header("-ETC")]
    public GameObject controlPanel;
    
    [HideInInspector]
    public float mapSize = 23f;
    public Slider timeMultSlider;


    public TextMeshProUGUI timeScaleText;
    
    
    void Awake()
    {
        instance = this;
        foodTime = new WaitForSeconds(foodRate);

        //StartSimulation(); //JH - Button에 연결
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
        
        controlPanel.SetActive(false);
        
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

    public void SetFoodAmount(bool inc)
    {
        initialFoodAmount += inc ? 1 : -1;

        if (initialFoodAmount <= 0)
            initialFoodAmount = 0;

        foodAmountText.text = initialFoodAmount.ToString();
    }
    
    public void SetDoveAmount(bool inc)
    {
        initialDoveAmount += inc ? 1 : -1;

        if (initialDoveAmount <= 0)
            initialDoveAmount = 0;

        doveAmountText.text = initialDoveAmount.ToString();
    }
    
    public void SetHawkAmount(bool inc)
    {
        initialHawkAmount += inc ? 1 : -1;

        if (initialHawkAmount <= 0)
            initialHawkAmount = 0;

        hawkAmountText.text = initialHawkAmount.ToString();
    }
}
