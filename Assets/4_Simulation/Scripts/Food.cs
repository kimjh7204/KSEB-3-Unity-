using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    private int energy = 10;
    private List<Blob> owner;
    private bool isHawk;
    private bool isDestroyed;
    
    public void SetOwner(Blob blob)
    {
        if (blob is Hawk)
            isHawk = true;
        owner.Add(blob);
    }
    
    public void TakeFood()
    {
        energy--;

        if (energy < 0)
        {
            foreach (var o in owner)
            {
                o.ResetFood();
            }

            isDestroyed = true;
            Destroy(gameObject);
        }
    }

    public bool IsHawkEating()
    {
        return isHawk;
    }

    public bool IsDestroyed() => isDestroyed;
}
