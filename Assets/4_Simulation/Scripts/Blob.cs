using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.PlayerLoop;

public abstract class Blob : MonoBehaviour
{
    protected FSMstate idleState;
    protected FSMstate wanderingState;
    protected FSMstate TracingFoodState;
    protected FSMstate eatingState;
    
    protected FSMstate curState;
    protected FSMstate nextState;
    
    private bool isTransition;
    
    protected NavMeshAgent agent;

    protected Food targetFood;
    
    private void Awake()
    {
        StateInit();
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (isTransition)
        {
            curState = nextState;
            curState.OnEnter?.Invoke();
            isTransition = false;
        }
        
        curState.OnUpdate?.Invoke();
        isTransition = TransitionCheck();

        if (isTransition) curState.OnExit?.Invoke();
    }

    protected abstract void StateInit();
    protected abstract bool TransitionCheck();

    public void ResetFood()
    {
        targetFood = null;
    }
}
