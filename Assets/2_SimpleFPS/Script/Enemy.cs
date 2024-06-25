using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private NavMeshAgent agent;
    private float healthPoint = 100f;

    private bool isArrived = true;
    private Vector3 targetPos;
    private const float MoveRange = 5f;
    
    public void Init(float hp)
    {
        healthPoint = hp;
    }

    public void GetDamage(float dmg)
    {
        healthPoint -= dmg;

        if (healthPoint < 0)
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        //agent.SetDestination(new Vector3(0f, 0f, 0f));
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
    }
}
