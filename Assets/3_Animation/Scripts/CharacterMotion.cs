using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.InputSystem;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class CharacterMotion : MonoBehaviour
{
    private Animator ani;
    public Transform camPivot;

    private Vector3 characterDir;
    private Vector2 moveVector;
    
    public float moveSpeed;

    private bool isRunning = false;
    
    private static readonly int IsMoving = Animator.StringToHash("isMoving");
    private static readonly int IsRun = Animator.StringToHash("isRun");
    private static readonly int JumpTrigger = Animator.StringToHash("jump");

    private void Awake()
    {
        
    }

    void Start()
    {
        ani = GetComponent<Animator>();
    }

    private void Update()
    {
        camPivot.position = transform.position;
        
        var threeDDir = new Vector3(moveVector.x, 0f, moveVector.y);
        characterDir = Vector3.Slerp(characterDir, threeDDir, 0.5f);
        
        transform.Translate(characterDir * moveSpeed * Time.deltaTime, Space.World);
        
        transform.LookAt(transform.position + characterDir, Vector3.up);
        
    }

    public void WalkForward(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            ani.SetBool(IsMoving, true);
            moveVector = context.ReadValue<Vector2>();
        }
        
        if (context.canceled)
        {
            ani.SetBool(IsMoving, false);
            moveVector = Vector2.zero;
        }
    }

    public void RunPhase(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            ani.SetBool(IsRun, true);
            isRunning = true;
        }
        
        if (context.canceled)
        {
            ani.SetBool(IsRun, false);
            isRunning = false;
        }
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            ani.SetTrigger(JumpTrigger);
        }
    }
}
