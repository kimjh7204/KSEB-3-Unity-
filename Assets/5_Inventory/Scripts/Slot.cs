using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public InventorySystem inventorySystem;
    private ItemData itemData;
    
    public Image itemImage;

    private bool _isFilled = false;
    public bool isFilled => _isFilled;
    
    public void SetItem(ItemData data)
    {
        itemData = data;
        
        itemImage.sprite = data.itemImage;

        var tempColor = itemImage.color;
        tempColor.a = 1f;
        itemImage.color = tempColor;
         
        _isFilled = true;
    }

    public void MouseEnter()
    {
        if (itemData == null) return;
        
        inventorySystem.InitTooltip(itemData);
    }

    public void MouseExit()
    {
        inventorySystem.ExitTooltip();
    }

    public void MouseMove(Vector2 pos)
    {
        inventorySystem.TooltipMove(pos);
    }

    public void MouseDown(ItemIcon icon)
    {
        inventorySystem.InitDrag(icon);
    }
}
