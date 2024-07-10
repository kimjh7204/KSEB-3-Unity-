using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class TestResourceLoad : MonoBehaviour
{
    private GameObject obj1;
    private GameObject obj2;
    
    void Start()
    {
        // obj1 = Resources.Load<GameObject>("Dove");
        // obj2 = Resources.Load<GameObject>("Hawk");
        //
        // if (obj1 != null) Debug.Log(obj1.name);
        // if (obj2 != null) Debug.Log(obj2.name);
        //
        // Instantiate(obj1, new Vector3(1f, 0f, 0f), Quaternion.identity);
        // Instantiate(obj2, new Vector3(-1f, 0f, 0f), Quaternion.identity);
        //
        LoadResource().Forget();
    }

    private async UniTask LoadResource()
    {
        var doveObj = (await Resources.LoadAsync<GameObject>("Dove")) as GameObject;
        var hawkObj = (await Resources.LoadAsync<GameObject>("Hawk")) as GameObject;
        
        if (doveObj == null)
        {
            Debug.LogError("Load process is failed");
            return;
        }
        
        if (hawkObj == null)
        {
            Debug.LogError("Load process is failed");
            return;
        }
        
        Debug.Log(doveObj.name);
        Debug.Log(hawkObj.name);

        Instantiate(doveObj, new Vector3(1f, 0f, 0f), Quaternion.identity);
        Instantiate(hawkObj, new Vector3(-1f, 0f, 0f), Quaternion.identity);
    }

    //private IEnumerator TestCoroutine()
    //{
        // yield return null; //await 1 frame
        // yield return new WaitForSeconds(1f);
        // yield return new WaitWhile();
        // yield return new WaitUntil();
    //}

    private async UniTask TestUniTask(string path)
    {
        // await UniTask.NextFrame();
        // await UniTask.WaitForSeconds(1f);
        // await UniTask.WaitWhile(() => 1 > 0);
        // await UniTask.WaitUntil();
        //
        // await UniTask.WhenAll(LoadResource(), TestUniTask("a"), TestUniTask("b"), TestUniTask("c"));
    }
    
    void Update()
    {
        
    }
}
