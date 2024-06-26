using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : Weapon
{
    public GameObject bullet;

    protected override void Fire()
    {
        muzzleFlash.Play();
            
        //bullet 생성
        var tempBullet = Instantiate(bullet, muzzle.position, transform.rotation);
        tempBullet.GetComponent<Bullet>().Init(bulletSpeed, dmg);
    }
}
