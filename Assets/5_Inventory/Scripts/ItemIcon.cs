using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemIcon : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerMoveHandler
{
    public Slot slot;
    
    public void OnPointerEnter(PointerEventData eventData)
    {
        slot.MouseEnter();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("Exit");
    }

    public void OnPointerMove(PointerEventData eventData)
    {
        Debug.Log("Move");
    }
}
