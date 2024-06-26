using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float moveSpeed;
    public float rotateXSpeed;
    public float rotateYSpeed;
    public Transform headPivot;

    private Rigidbody rigid;
    private bool enableJump = false;
    public float jumpForce;

    private float rotationX = 0f; //-90 ~ 90
    
    public Transform muzzle;

    private int healthPoint = MaxHealthPoint;
    private const int MaxHealthPoint = 3;

    public Image[] HeartImages;

    private bool invincible = false;

    public Weapon[] Weapons;
    private Weapon curWeapon;
    
    public bool hideCursor = true;
    void Start()
    {
        if (hideCursor)
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }

        rigid = GetComponent<Rigidbody>();
        
        //시작 무기
        Weapons[0].gameObject.SetActive(true);
        Weapons[0].Init(muzzle);

        curWeapon = Weapons[0];
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
        //좌우 회전
        transform.Rotate(Vector3.up, Input.GetAxis("Mouse X") * rotateXSpeed);
        //상하 회전
        rotationX -= Input.GetAxis("Mouse Y") * rotateYSpeed;
        rotationX = Mathf.Clamp(rotationX, -90f, 90f);
        
        var tempRotation = headPivot.eulerAngles;
        tempRotation.x = rotationX;
        headPivot.rotation = Quaternion.Euler(tempRotation);
        
        //Jump
        if (Input.GetKeyDown(KeyCode.Space) && enableJump)
        {
            rigid.AddForce(0f, jumpForce, 0f, ForceMode.Impulse);
            enableJump = false;
        }
        
        if(Input.GetKeyDown(KeyCode.Alpha1))
            SelectWeapon(0);
        if(Input.GetKeyDown(KeyCode.Alpha2))
            SelectWeapon(1);
        if(Input.GetKeyDown(KeyCode.Alpha3))
            SelectWeapon(2);
    }

    private void GetDamage(Vector3 enemyPos)
    {
        invincible = true;
        StartCoroutine(InvincibleTimer());
        
        healthPoint--;
        
        var hitVector = (transform.position - enemyPos).normalized * 4f;
        hitVector += Vector3.up * 3f;
        rigid.AddForce(hitVector, ForceMode.Impulse);
        
        if (healthPoint < 0) return;
        
        HeartImages[healthPoint].enabled = false;
    }
    
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.layer == 6)
            enableJump = true;

        if (other.gameObject.layer == 7)
        {
            if (invincible) return;
            
            GetDamage(other.transform.position);
        }
    }

    private void SelectWeapon(int idx)
    {
        curWeapon.gameObject.SetActive(false);
        
        Weapons[idx].gameObject.SetActive(true);
        Weapons[idx].Init(muzzle);

        curWeapon = Weapons[idx];
    }
    
    private IEnumerator InvincibleTimer()
    {
        yield return new WaitForSeconds(2f);
        invincible = false;
    }
}
