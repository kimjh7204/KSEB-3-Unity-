using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterMotion : MonoBehaviour
{
    private Animator ani;
    
    void Start()
    {
        ani = GetComponent<Animator>();
    }

    public void WalkForward(InputAction.CallbackContext context)
    {
        ani.SetBool("isWalking", true);
    }
}
