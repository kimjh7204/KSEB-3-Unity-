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

    public float moveSpeed;
    
    void Start()
    {
        ani = GetComponent<Animator>();
    }

    private void Update()
    {
        camPivot.position = transform.position;
        transform.Translate(characterDir * moveSpeed * Time.deltaTime);
    }

    public void WalkForward(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            ani.SetBool("isWalking", true);
        }

        if (context.performed)
        {
            var dir = context.ReadValue<Vector2>();
            var threeDDir = new Vector3(dir.x, 0f, dir.y);
            characterDir = Vector3.Slerp(characterDir, threeDDir, 0.5f);
        }

        if (context.canceled)
        {
            ani.SetBool("isWalking", false);
        }
    }
}
