using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Extentions
{
    public static float SumXYZ(this Vector3 vec)
    {
        return vec.x + vec.y + vec.z;
    }
}
