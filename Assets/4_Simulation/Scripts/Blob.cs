using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public abstract class Blob : MonoBehaviour
{
    private FSMstate idle;
    
    private FSMstate curState;
    private FSMstate nextState;
    
    private bool isTransition;
    
    private void Awake()
    {
        StateInit();
    }

    private void Update()
    {
        if (isTransition)
        {
            curState = nextState;
            curState.OnEnter();
            isTransition = false;
        }
        
        curState.OnUpdate();
        isTransition = TransitionCheck();

        if (isTransition) curState.OnExit();
    }

    protected abstract void StateInit();
    protected abstract bool TransitionCheck();
}
