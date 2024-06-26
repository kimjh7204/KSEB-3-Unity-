using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    private float grenadeDamage;
    
    private bool isInit = false;

    private float timeCounter = 0f;
    private const float MaxTime = 5f;

    public GameObject hitEffect;
    
    public void Init(float dmg)
    {
        grenadeDamage = dmg;
        
        isInit = true;
    }
    
    void Start()
    {
        if (isInit) return;
        
        Debug.LogError("Bullet is not initiated!");
        Destroy(gameObject);
    }

    void Update()
    {
        timeCounter += Time.deltaTime;
        if(timeCounter > MaxTime)
            Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.layer == 7)
        {
            other.transform.GetComponent<Enemy>().GetDamage(grenadeDamage);
            
            Instantiate(hitEffect, transform.position, Quaternion.identity);
            
            Destroy(gameObject);
        }
    }

    // private void OnTriggerEnter(Collider other)
    // {
    //     if (other.gameObject.layer == 7)
    //     {
    //         other.GetComponent<Enemy>().GetDamage(grenadeDamage);
    //         
    //         Instantiate(hitEffect, transform.position, Quaternion.identity);
    //         
    //         Destroy(gameObject);
    //     }
    // }
}
