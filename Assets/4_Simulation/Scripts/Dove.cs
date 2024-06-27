using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dove : Blob
{
    public float idleTime = 3f;
    private float idleTimer;

    private Vector3 WanderingPos;

    protected override void StateInit()
    {
        idleState = new FSMstate(IdleEnter, null, null);
        wanderingState = new FSMstate(WanderingEnter, null, null);
        curState = idleState;
    }

    protected override bool TransitionCheck()
    {
        if (curState == idleState)
        {
            idleTimer += Time.deltaTime;

            if (idleTimer > idleTime)
            {
                nextState = wanderingState;
                return true;
            }
        }
        else if(curState == wanderingState)
        {
            if (Vector3.Distance(transform.position, WanderingPos) < 1.1f)
            {
                nextState = idleState;
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
        WanderingPos.y = 0f;
        
        agent.SetDestination(targetPos);
    }
}
