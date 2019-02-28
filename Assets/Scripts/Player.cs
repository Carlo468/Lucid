using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    
    public static int numKeys;
    GameObject a;

    private void OnCollisionEnter(Collision collision)
    {
        print("I hit (collided with)" + collision.gameObject.name);
        if (collision.gameObject.tag == "key")
        {
            
            numKeys++;
           // spawnps(collision.transform);
            Destroy(collision.gameObject);
        }
    }

    void Update()
    {
        if (numKeys == 3)
        {
            a = GameObject.FindWithTag("final wall");
            Destroy(a);
        }
    }
   
}
