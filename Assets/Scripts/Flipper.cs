using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flipper : MonoBehaviour
{
    public static void FlipSprite( GameObject obj, bool left)
    {
        if ( left == true )
        {
            obj.transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
        else
        {
            obj.transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
    }
}
