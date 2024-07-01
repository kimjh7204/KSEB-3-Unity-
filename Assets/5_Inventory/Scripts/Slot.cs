using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public Image itemImage;

    private bool _isFilled = false;
    public bool isFilled => _isFilled;
    
    public void SetItem(ItemData data)
    {
        itemImage.sprite = data.itemImage;

        var tempColor = itemImage.color;
        tempColor.a = 1f;
        itemImage.color = tempColor;
         
        _isFilled = true;
    }
}
