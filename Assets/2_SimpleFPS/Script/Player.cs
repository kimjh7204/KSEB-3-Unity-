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

    public bool hideCursor = true;

    public GameObject bullet;
    public Transform muzzle;

    private int healthPoint = MaxHealthPoint;
    private const int MaxHealthPoint = 3;

    public Image[] HeartImages;

    private bool invincible = false;
    
    public float dmg;
    public float bulletSpeed;
    
    void Start()
    {
        if (hideCursor)
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }

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

        //fire bullet
        if (Input.GetMouseButtonDown(0))
        {
            //bullet 생성
            var tempBullet = Instantiate(bullet, muzzle.position, headPivot.rotation);
            tempBullet.GetComponent<Bullet>().Init(bulletSpeed, dmg);
        }
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

    private IEnumerator InvincibleTimer()
    {
        yield return new WaitForSeconds(2f);
        invincible = false;
    }
}
