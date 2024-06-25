using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    private Rigidbody rigid;
    public float jumpForce;
    private bool enableJump = false;
    private int jumpCounter = 0; 
    
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && jumpCounter < 2)
        {
            rigid.AddForce(0f, jumpForce, 0f, ForceMode.Impulse);
            jumpCounter++;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.layer == 6)
        {
            jumpCounter = 0;
        }
    }

    // private void OnCollisionExit(Collision other)
    // {
    //     if (other.gameObject.layer == 6)
    //     {
    //         enableJump = false;
    //     }
    // }
}
