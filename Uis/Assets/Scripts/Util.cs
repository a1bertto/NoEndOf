using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  static class Util
{
    
    public static void ResetTransform(this Transform transform)
    {
        Vector3 offset = new Vector3(-0.181999996f, -0.0439999998f, 0.00800000038f);
        transform.localPosition = Vector3.zero + offset;

    }
    
}
