using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{


    public static int numKeys;
    public static Player instance;
    GameObject a;
    GameObject b;
    GameObject go;
    Transform startPos;
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
        a = GameObject.FindWithTag("WP");
        if (a != null)
        {
            Debug.Log("setting the walls");
            //b.SetActive(false);
        }
        startPos = transform;

        

        /*
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
        */
    }

    private void OnCollisionEnter(Collision collision)
    {
        print("I hit (collided with)" + collision.gameObject.name);
        if (collision.gameObject.tag == "key")
        {


            // spawnps(collision.transform);
            Destroy(collision.gameObject);
        }
    }

    private void OnTriggerEnter(Collider coll)
    {
        //bring the player to the forest level
        print("I hit (collided with)" + coll.gameObject.name);
        if (coll.gameObject.tag == "woodDoor")
        {
            SceneManager.LoadScene("forestLevel");
        }

        if (coll.gameObject.tag == "killbox")
        {
            Debug.Log("respawning");
            playerRespawn();
        }
        //this brings the player to the desert level
        print("I hit (collided with)" + coll.gameObject.name);
        if (coll.gameObject.tag == "DesertDoor")
        {
            SceneManager.LoadScene("Desert");
        }


        //this brings the player to the space level
        print("I hit (collided with)" + coll.gameObject.name);
        if (coll.gameObject.tag == "Spacedoor")
        {
            SceneManager.LoadScene("spacelevel");


            if (coll.gameObject.tag == "SpaceDoor")
            {
                SceneManager.LoadScene("spaceLevel");

            }
        }


        if (coll.gameObject.tag == "SpaceDoor")
        {
            SceneManager.LoadScene("spaceLevel");

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


            a.SetActive(false);
            //Destroy(a);

            if (b != null)
            {
                b.SetActive(true);
            }


        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
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

    void playerRespawn()
    {

        gameObject.SetActive(false);
        transform.Translate(startPos.transform.position);
        gameObject.SetActive(true);
    }

}




   


