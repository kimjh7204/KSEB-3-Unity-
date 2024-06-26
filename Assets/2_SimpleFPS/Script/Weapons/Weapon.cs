using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public float dmg;
    
    public ParticleSystem muzzleFlash;

    protected Transform muzzle;

    public bool isFullAuto;
    
    void Update()
    {
        if (isFullAuto && Input.GetMouseButton(0))
        {
            Fire();
        }
        else if (Input.GetMouseButtonDown(0))
        {
            Fire();
        }
        
        if(isFullAuto && Input.GetMouseButtonUp(0))
            OnRelease();
    }

    public void Init(Transform muzzlePos)
    {
        muzzle = muzzlePos;
    }
    protected abstract void Fire();
    protected abstract void OnRelease();
}
