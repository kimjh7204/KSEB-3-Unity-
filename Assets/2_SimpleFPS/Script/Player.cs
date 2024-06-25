using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed;
    public float rotateXSpeed;
    public float rotateYSpeed;
    public Transform headPivot;

    private Rigidbody rigid;
    private bool enableJump = false;
    public float jumpForce;

    public float rotation1;
    
    void Start()
    {
        //Cursor.visible = false;
        //Cursor.lockState = CursorLockMode.Locked;

        rigid = GetComponent<Rigidbody>();
    }
    
    void Update()
    {
        //Move
        Vector3 moveVector = Vector3.zero;
        
        if (Input.GetKey(KeyCode.W))
        {
            moveVector += Vector3.forward;
        }
        if (Input.GetKey(KeyCode.A))
        {
            moveVector += Vector3.left;
        }
        if (Input.GetKey(KeyCode.S))
        {
            moveVector += Vector3.back;
        }
        if (Input.GetKey(KeyCode.D))
        {
            moveVector += Vector3.right;
        }
        
        moveVector.Normalize();
        transform.Translate(moveVector * (moveSpeed * Time.deltaTime));
        
        //rotate
        transform.Rotate(Vector3.up, Input.GetAxis("Mouse X") * rotateXSpeed);
        //headPivot.Rotate(Vector3.right, -Input.GetAxis("Mouse Y") * rotateYSpeed);
        
        //headPivot.rotation = Quaternion.Euler(temp);
        
        //Jump
        if (Input.GetKeyDown(KeyCode.Space) && enableJump)
        {
            rigid.AddForce(0f, jumpForce, 0f, ForceMode.Impulse);
            enableJump = false;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.layer == 6)
            enableJump = true;
    }
}
