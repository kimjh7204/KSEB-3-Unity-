using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float healthPoint = 100f;

    public void Init(float hp)
    {
        healthPoint = hp;
    }

    public void GetDamage(float dmg)
    {
        healthPoint -= dmg;

        if (healthPoint < 0)
        {
            Destroy(gameObject);
        }
    }
}
