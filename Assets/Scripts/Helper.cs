using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Globals;

public class Helper : MonoBehaviour
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

    public static int GetObjectDir( GameObject obj )
    {
        float ang = obj.transform.eulerAngles.y;
        if( ang == 180 )
        {
            return Left;
        }
        else
            return Right;
    }


    public static void MakeBullet( GameObject prefab,  float xpos, float ypos, float xvel, float yvel, bool left )
    {
        // instantiate the object at xpos,ypos
        GameObject instance = Instantiate(prefab, new Vector3(xpos,ypos,0), Quaternion.identity);
        
        // set the direction of the instance based on the anim bool left
        if (left == true)
        {
            xvel = -9;
            Helper.FlipSprite(instance, true);

        }
        else
        {
            xvel = 9;
            Helper.FlipSprite(instance, false);
        }

        // set the velocity of the instantiated object
        Rigidbody2D rb = instance.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector3( xvel, yvel, 0 );
            
    }
    
}
