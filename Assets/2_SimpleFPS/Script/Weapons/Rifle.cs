using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rifle : Weapon
{
    public float fireRate;
    public LineRenderer line;

    private float timer = 0f;

    
    
    protected override void Fire()
    {
        timer += Time.deltaTime;
        
        if (timer > fireRate)
        {
            muzzleFlash.Play();
            
            //Line render
            line.enabled = true;
            var randomPos = Random.insideUnitCircle;
            var targetPos = new Vector3(randomPos.x, randomPos.y, 50f);
            
            line.SetPosition(1, targetPos);
            timer -= fireRate;

            
            //실제 총알 궤적
            var bulletDir = muzzle.rotation * targetPos;
            
            if (Physics.Raycast(muzzle.position, bulletDir, out var hit,100f, 1 << 7))
            {
                hit.transform.GetComponent<Enemy>().GetDamage(dmg);
            }
        }
    }

    protected override void OnRelease()
    {
        timer = 0f;
        line.enabled = false;
    }
}
