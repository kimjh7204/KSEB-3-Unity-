using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereMover : MonoBehaviour
{
    private ObjPool objPool;
    public void Init(float angle, ObjPool pool)
    {
        transform.position = Vector3.zero;
        transform.RotateAround(Vector3.zero, Vector3.up, angle);

        objPool = pool;

        StartCoroutine(Delay());
    }
    
    void Update()
    {
        transform.Translate(0f,0f, 5f * Time.deltaTime);
    }

    private IEnumerator Delay()
    {
        yield return new WaitForSeconds(3f);
        
        objPool.SetObj(this);
    }
}
