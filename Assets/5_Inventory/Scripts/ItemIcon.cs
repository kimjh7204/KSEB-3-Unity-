using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;

public class ItemIcon : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerMoveHandler, IPointerDownHandler
{
    public Slot slot;
    public Vector2 posOffset;

    private RectTransform rectTransform;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public void SetPos(Vector2 pos)
    {
        rectTransform.anchoredPosition = pos - posOffset;
    }
    
    public void OnPointerEnter(PointerEventData eventData)
    {
        slot.MouseEnter();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        slot.MouseExit();
    }

    public void OnPointerMove(PointerEventData eventData)
    {
        slot.MouseMove(eventData.position);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        slot.MouseDown(this);
        posOffset = eventData.position - rectTransform.anchoredPosition;
    }

    public void Reset()
    {
        transform.SetParent(slot.transform);
        rectTransform.anchoredPosition = new Vector2(50f, 50f);
        slot.Reset();
    }

    public void BackToSlot()
    {
        transform.SetParent(slot.transform);
        rectTransform.anchoredPosition = new Vector2(50f, 50f);
        slot.BackToSlot();
    }
    
}
