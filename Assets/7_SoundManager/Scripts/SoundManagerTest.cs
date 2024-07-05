using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            SoundManager.instance.PlaySound("s1", Vector3.zero);
        }
        
        if (Input.GetKeyDown(KeyCode.S))
        {
            SoundManager.instance.PlaySound("s2", Vector3.zero);
        }
    }
}
