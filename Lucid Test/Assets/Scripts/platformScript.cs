using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformScript : MonoBehaviour
{
    bool hasCollided;
    GameObject playerPrefab;
    public GameObject theParent;
    Vector3 scale;
    // Start is called before the first frame update
    void Start()
    {
        playerPrefab = GameObject.FindWithTag("Player");
        //scale = playerPrefab.transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        //playerPrefab.transform.localScale = scale;
        //playerPrefab.transform.rotation = Quaternion.identity;

        if (hasCollided)
        {

            //playerPrefab.transform.position = transform.position;

        }
        
    }
    void OnTriggerEnter(Collider coll)
    {
        print("I the platform has collided with: " + coll.name);
        
        if(coll.gameObject.tag == "Player")
        {
            print("The player hit me!");
            hasCollided = true;
            //playerPrefab.transform.parent = theParent.transform;
            //playerPrefab.transform.localScale = scale;
            //coll.gameObject.transform.position = gameObject.transform.position;
            //coll.gameObject.transform.parent = transform.parent;


        }
    }
    void OnTriggerExit(Collider coll)
    {
        //
        if (coll.gameObject.tag == "Player")
        {
            hasCollided = false;
            playerPrefab.transform.parent = null;
        }
    }
}
