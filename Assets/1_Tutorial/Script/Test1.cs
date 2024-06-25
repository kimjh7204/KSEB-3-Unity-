using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test1 : MonoBehaviour
{
    private Transform trans;
    private Vector3 move = new Vector3(0f, 0f, 0f);
    public float speed;
    
    void Start()
    {
        Debug.Log("Test log");
        trans = GetComponent<Transform>();
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            move = new Vector3(0f, 0f, speed * Time.deltaTime); //sec
        }
        else if (Input.GetKey(KeyCode.A))
        {
            move = new Vector3(-speed * Time.deltaTime, 0f, 0f);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            move = new Vector3(0f, 0f, -speed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            move = new Vector3(speed * Time.deltaTime, 0f, 0f);
        }
        else
        {
            move = new Vector3(0f, 0f, 0f);
        }
        
        trans.Translate(move);
    }
}
