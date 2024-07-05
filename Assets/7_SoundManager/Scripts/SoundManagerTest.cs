using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerTest : MonoBehaviour
{
    public Transform test;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            SoundManager.instance.PlaySound("s1", Vector3.left * 10f);
        }
        
        if (Input.GetKeyDown(KeyCode.S))
        {
            SoundManager.instance.PlaySound("s1", Vector3.right * 10f);
        }
        
        if (Input.GetKeyDown(KeyCode.D))
        {
            SoundManager.instance.PlaySound("s1", test);
        }
    }
}
