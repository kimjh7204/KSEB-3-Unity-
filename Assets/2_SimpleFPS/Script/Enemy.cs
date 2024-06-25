using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;

public class Enemy : MonoBehaviour
{
    private NavMeshAgent agent;
    private float healthPoint = 100f;
    private float maxHealthPoint;
    
    private bool isArrived = true;
    private Vector3 targetPos;
    private const float MoveRange = 5f;

    public GameObject hpBarPrefab;
    private HpBar hpBar;
    
    public void Init(float hp)
    {
        healthPoint = hp;
        maxHealthPoint = healthPoint;
    }

    public void GetDamage(float dmg)
    {
        healthPoint -= dmg;

        hpBar.SetHp(healthPoint / maxHealthPoint);
        
        if (healthPoint < 0)
        {
            Destroy(gameObject);
            Destroy(hpBar.gameObject);
        }
    }

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        hpBar = Instantiate(hpBarPrefab, GameManager.instance.canvasTransform).GetComponent<HpBar>();
    }

    private void Update()
    {
        if (isArrived)
        {
            var randPos = Random.insideUnitCircle;
            targetPos = new Vector3(randPos.x, 0f, randPos.y) * MoveRange + transform.position;
            agent.SetDestination(targetPos);
            
            isArrived = false;
        }

        if (Vector3.Distance(transform.position, targetPos) < 1.1f)
        {
            isArrived = true;
        }
        
        hpBar.SetPosition(transform.position + Vector3.up * 2f);
    }
}
