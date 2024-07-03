using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventorySystem : MonoBehaviour
{
    public ItemData[] itemDataGroup;
    public Dictionary<string, ItemData> itemDB;
    
    public Slot[] itemSlots;

    // tooltip
    public GameObject tooltipObj;
    public RectTransform tooltipTransform;
    public TextMeshProUGUI tooltipItemName;
    public TextMeshProUGUI tooltipItemDesc;

    public RectTransform iconLayer;

    private ItemIcon icon;

    private bool isPointerInBG;
    private bool isPointerInFrame;
    
    private Slot focusedSlot;
    public Slot FocusedSlot => focusedSlot;
    
    void Start()
    {
        itemDB = new Dictionary<string, ItemData>();
        foreach (var data in itemDataGroup)
        {
            itemDB.Add(data.name, data);
        }
        
        foreach (var itemKey in itemDB.Keys)
        {
            SetItem(itemKey);
        }
    }

    private void Update()
    {
        if(icon == null) return;
        
        icon.SetPos(Input.mousePosition);

        if (Input.GetMouseButtonUp(0))
        {
            if (isPointerInBG)
            {
                icon.Reset();
            }

            if (isPointerInFrame)
            {
                if (focusedSlot != null)
                {
                    focusedSlot.SetItem(icon.slot.ItemData);
                    icon.Reset();
                }
                else
                {
                    icon.BackToSlot();
                }
            }

            
            
            icon = null;
        }
    }

    public bool SetItem(string itemKey)
    {
        Slot targetSlot = null;
        for (var i = 0; i < itemSlots.Length; i++)
        {
            if (!itemSlots[i].isFilled)
            {
                targetSlot = itemSlots[i];
                break;
            }
        }

        if (targetSlot == null) return false;

        targetSlot.SetItem(itemDB[itemKey]);

        return true;
    }

    public void InitTooltip(ItemData itemData)
    {
        tooltipObj.SetActive(true);
        
        tooltipItemName.text = itemData.itemName;
        tooltipItemDesc.text = itemData.itemDesc;
    }

    public void ExitTooltip()
    {
        tooltipObj.SetActive(false);
    }

    public void TooltipMove(Vector2 pos)
    {
        tooltipTransform.anchoredPosition = pos;
    }

    public void InitDrag(ItemIcon itemIcon)
    {
        icon = itemIcon;
        
        icon.transform.SetParent(iconLayer);
        icon.GetComponent<Image>().raycastTarget = false;
        tooltipObj.SetActive(false);
        
        //icon.SetPos();
    }
    
    public void OnBGEnter(BaseEventData eventData)
    {
        isPointerInBG = true;
    }
    
    public void OnBGExit(BaseEventData eventData)
    {
        isPointerInBG = false;
    }
    
    public void OnFrameEnter(BaseEventData eventData)
    {
        isPointerInFrame = true;
    }
    
    public void OnFrameExit(BaseEventData eventData)
    {
        isPointerInFrame = false;
    }

    public void SetFocusedSlot(Slot slot)
    {
        focusedSlot = slot;
    }
}
