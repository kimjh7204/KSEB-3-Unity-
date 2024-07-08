using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestUIAni : MonoBehaviour
{
    private Animator ani;
    
    void Start()
    {
        ani = GetComponent<Animator>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            ani.SetBool("active", true);
        }
    }

    public void CloseWindow()
    {
        ani.SetBool("active", false);
    }
}
