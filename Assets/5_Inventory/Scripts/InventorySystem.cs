using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

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
    
}
