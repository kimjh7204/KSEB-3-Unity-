using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjPool : MonoBehaviour
{
    public int poolSize;
    public GameObject prefab;

    public Queue<SphereMover> pool = new();
    
    void Awake()
    {
        for (int i = 0; i < poolSize; i++)
        {
            var tempObj = Instantiate(prefab);
            tempObj.SetActive(false);
            
            var sphereMover = tempObj.GetComponent<SphereMover>();
            pool.Enqueue(sphereMover);
        }
    }

    public SphereMover GetObj()
    {
        var sphereMover = pool.Dequeue();
        sphereMover.gameObject.SetActive(true);
        return sphereMover;
    }

    public void SetObj(SphereMover sphereMover)
    {
        sphereMover.gameObject.SetActive(false);
        pool.Enqueue(sphereMover);
    }
}
