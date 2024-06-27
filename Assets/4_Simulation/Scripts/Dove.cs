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
        TracingFoodState = new FSMstate(TracingFood, null, null);
        eatingState = new FSMstate(null, null, null);//JH
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

            return CheckFoodInRange();

        }
        else if(curState == wanderingState)
        {
            if (Vector3.Distance(transform.position, WanderingPos) < 1.1f)
            {
                nextState = idleState;
                return true;
            }

            return CheckFoodInRange();
        }
        else if (curState == TracingFoodState)
        {
            if (targetFood.IsDestroyed() || targetFood.IsHawkEating())
            {
                nextState = wanderingState;
                return true;
            }
            
            
            if (Vector3.Distance(transform.position, targetFood.transform.position) < 1.1f)
            {
                nextState = eatingState;
                return true;
            }

        }

        return false;
    }

    private bool CheckFoodInRange()
    {
        var foods = Physics.OverlapSphere(transform.position, 5f, 1 << LayerMask.NameToLayer("Food"));

        if (foods.Length < 1)
        {
            return false;
        }
            
        var min = float.MaxValue;
        for (int i = 0; i < foods.Length; i++)
        {
            var dist = Vector3.Distance(transform.position, foods[i].transform.position);

            if (dist < min)
            {
                min = dist;
                targetFood = foods[i].GetComponent<Food>();
            }
        }

        nextState = TracingFoodState;
        return true;
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

    private void TracingFood()
    {
        agent.SetDestination(targetFood.transform.position);
    }
}
