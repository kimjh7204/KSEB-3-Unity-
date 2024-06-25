using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float bulletSpeed;
    private float bulletDamage;

    private bool isInit = false;

    private float timeCounter = 0f;
    private const float MaxTime = 5f;
    
    public void Init(float speed, float dmg)
    {
        bulletSpeed = speed;
        bulletDamage = dmg;

        isInit = true;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        // if (!isInit)
        // {
        //     Debug.LogError("Bullet is not initiated!");
        //     Destroy(gameObject);
        // }
        if (isInit) return;
        
        Debug.LogError("Bullet is not initiated!");
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0f, 0f, bulletSpeed * Time.deltaTime);

        timeCounter += Time.deltaTime;
        if(timeCounter > MaxTime)
            Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 7)
        {
            other.GetComponent<Enemy>().GetDamage(bulletDamage);
            Destroy(gameObject);
        }
    }
}
