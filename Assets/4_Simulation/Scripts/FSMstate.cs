using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSMstate
{
    public Action OnEnter;
    public Action OnUpdate;
    public Action OnExit;

    public FSMstate(Action onEnter, Action onUpdate, Action onExit)
    {
        OnEnter = onEnter;
        OnUpdate = onUpdate;
        OnExit = onExit;
    }
}