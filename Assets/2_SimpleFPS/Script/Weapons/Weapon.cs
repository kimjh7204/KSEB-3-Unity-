using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public float dmg;
    public float bulletSpeed;
    
    public ParticleSystem muzzleFlash;

    protected Transform muzzle;
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Fire();
        }
    }

    public void Init(Transform muzzlePos)
    {
        muzzle = muzzlePos;
    }
    protected abstract void Fire();
}
