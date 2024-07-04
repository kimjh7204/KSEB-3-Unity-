using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjSpawner : MonoBehaviour
{
    public ObjPool objPool;

    private float degree;

    private WaitForSeconds delay = new WaitForSeconds(0.1f);
    
    void Start()
    {
        StartCoroutine(SpwanObj());
    }

    // Update is called once per frame
    void Update()
    {
        degree += Time.deltaTime * 720f;
    }

    private IEnumerator SpwanObj()
    {
        while (true)
        {
            yield return delay;

            var sphereMover = objPool.GetObj();
            sphereMover.Init(degree, objPool);
            
        }
    }
}
