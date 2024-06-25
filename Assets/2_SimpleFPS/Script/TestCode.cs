using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCode : MonoBehaviour
{
    public HpBar hp;

    [Range(0f, 1f)]
    public float percent;

    void Update()
    {
        hp.SetHp(percent);
    }
}
