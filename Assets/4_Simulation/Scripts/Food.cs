using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    private int energy = 10;
    private List<Blob> owner = new ();
    private bool isHawk;
    private bool isDestroyed;
    
    public void SetOwner(Blob blob)
    {
        if (blob is Hawk)
            isHawk = true;
        owner.Add(blob);
    }

    public void RemoveOwner(Blob blob)
    {
        owner.Remove(blob);
    }
    
    public void TakeFood()
    {
        energy--;

        if (energy < 0)
        {
            isDestroyed = true;
            Destroy(gameObject);
        }
    }

    public bool IsHawkEating() => isHawk;
    public bool IsDestroyed() => isDestroyed;

    public bool CheckEnemy()
    {
        if (isHawk)
        {
            isDestroyed = true;
            Destroy(gameObject);
            return false;
        }
        else
        {
            foreach (Dove dove in owner)
            {
                dove.SetKicked();
            }

            return true;
        }
    }
}
