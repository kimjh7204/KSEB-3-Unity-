using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public Image itemImage;

    private bool _isFilled = false;
    public bool isFilled => _isFilled;
    
    public void SetItem(/* Item data */)
    {
        //itemImage.sprite = 
        _isFilled = true;
    }
}
