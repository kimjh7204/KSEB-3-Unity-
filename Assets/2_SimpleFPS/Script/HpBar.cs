using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpBar : MonoBehaviour
{
    public RectTransform rect;

    private float max = 96f;
    
    public void SetHp(float percent) // 0 ~ 1
    {
        var size = rect.sizeDelta;
        size.x = max * percent;
        rect.sizeDelta = size;
    }


    public void SetPosition(Vector3 pos)
    {
        var cam = Camera.main;

        var active = Vector3.Angle(cam.transform.forward, pos - cam.transform.position) < 90f;
        gameObject.SetActive(active);

        
        if (!active) return;
        
        var uiPos = cam.WorldToScreenPoint(pos);
        transform.position = uiPos;
    }
}
