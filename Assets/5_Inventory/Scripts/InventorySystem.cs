using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    public ItemData[] itemDataGroup;
    public Dictionary<string, ItemData> itemDB;
    
    public Slot[] itemSlots;
    
    void Start()
    {
        itemDB = new Dictionary<string, ItemData>();
        foreach (var data in itemDataGroup)
        {
            itemDB.Add(data.name, data);
        }
        
        //SetItem 3번
    }

    public bool SetItem(ItemData data)
    {
        Slot targetSlot = null;
        for (var i = 0; i < itemSlots.Length; i++)
        {
            if (!itemSlots[i].isFilled)
            {
                targetSlot = itemSlots[i];
            }
        }

        if (targetSlot == null) return false;
        
        


    }
    
}
