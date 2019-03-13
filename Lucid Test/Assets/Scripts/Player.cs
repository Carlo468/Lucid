using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{


    public static int numKeys;
    GameObject a;
    GameObject b;
    GameObject go;
    public GameObject img;

    void Awake()
    {
        go = GameObject.FindWithTag("end");
        if (go != null)
            go.SetActive(false);

        b = GameObject.FindWithTag("FP");
        if (b != null)
        {
            Debug.Log("setting the platforms");
            b.SetActive(false);
        }
    }

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

    private void OnTriggerEnter(Collider coll)
    {
        print("I hit (collided with)" + coll.gameObject.name);
        if (coll.gameObject.tag == "woodDoor")
        {
            SceneManager.LoadScene("forestLevel");
        }
    }

    void Update()
    {
        if (numKeys == 2)
        {
            a = GameObject.FindWithTag("WP");
            if (a != null)
                Destroy(a);

            if (b != null)
            {
                b.SetActive(true);
            }

        }
        if (numKeys == 5)
        {
            a = GameObject.FindWithTag("final wall");
            if (a != null)
                Destroy(a);
        }

        if (numKeys == 6)
        {
            if (go != null)
                go.SetActive(true);
            //img.SetActive(true);
        }
    }

}
