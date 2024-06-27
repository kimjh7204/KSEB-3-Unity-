using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dove : Blob
{
    public float idleTime = 3f;
    private float idleTimer;

    private Vector3 WanderingPos;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected override void StateInit()
    {
        idleState = new FSMstate(IdleEnter, null, null);
    }

    protected override bool TransitionCheck()
    {
        if (curState == idleState)
        {
            idleTimer += Time.deltaTime;

            if (idleTimer > idleTime)
            {
                //nextState = <- 세팅
                return true;
            }
        }

        return false;
    }

    private void IdleEnter()
    {
        idleTimer = 0f;
    }

    private void WanderingEnter()
    {
        var mapSize = SimulationManager.instance.mapSize;

        var targetPos = Random.insideUnitSphere * 5f + transform.position;

        targetPos.x = Mathf.Clamp(targetPos.x, -mapSize, mapSize);
        targetPos.z = Mathf.Clamp(targetPos.z, -mapSize, mapSize);

        WanderingPos = targetPos;
        
        agent.SetDestination(targetPos);
    }
}
