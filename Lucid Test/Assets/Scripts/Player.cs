using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{


    public static int numKeys;
    public static Player instance;
    GameObject a;
    GameObject beginningWall;
    GameObject secondWall;
    GameObject b;
    GameObject go;
    GameObject kb;
    //GameObject pauseMenu;

    GameObject[] platforms;
    GameObject[] temp;

    Transform startPos;
    public GameObject img;

    

    void Awake()
    {
        beginningWall = GameObject.FindWithTag("BW");
        secondWall = GameObject.FindWithTag("SW");
        go = GameObject.FindWithTag("end");
        a = GameObject.FindWithTag("WP");
        platforms = GameObject.FindGameObjectsWithTag("platformGrab");
        temp = platforms;
        for(int i = 0; i<platforms.Length; i++)
        {
            
        }
        //pauseMenu = GameObject.FindWithTag("Pause");

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

        kb = GameObject.FindWithTag("killbox");

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

    
    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        print("I hit (collided with)" + hit.gameObject.name);
        Rigidbody body = hit.collider.attachedRigidbody;

        if (hit.gameObject.tag == "killbox")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

    }
    void OnCollisionEnter(Collision coll)
    {
        print("I hit (collided with)" + coll.gameObject.name);
        if(coll.gameObject.tag == "woodDoor" || coll.gameObject.tag == "DesertDoor" || coll.gameObject.tag == "Spacedoor")
        {
            print("KILLBOX DISABLED");
            kb.SetActive(false);
        }
        if (coll.gameObject.tag == "killbox" && SceneManager.GetActiveScene().name == "Nexus")
        {
            print("Im in nexus and hit the killbox");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }


    }
        private void OnTriggerEnter(Collider coll)
    {
        //bring the player to the forest level
        print("I hit (collided with)" + coll.gameObject.name);
        if (coll.gameObject.tag == "killbox")
        {
            Debug.Log("respawning");
            playerRespawn();
        }
        
        if (coll.gameObject.tag == "woodDoor" && SceneManager.GetActiveScene().name == "Nexus")
        {
            SceneManager.LoadScene("forestLevel");
        }

       
        //this brings the player to the desert level
        print("I hit (collided with)" + coll.gameObject.name);
        if (coll.gameObject.tag == "DesertDoor" && SceneManager.GetActiveScene().name == "Nexus")
        {
            SceneManager.LoadScene("Desert");
        }


        //this brings the player to the space level
        print("I hit (collided with)" + coll.gameObject.name);
        if (coll.gameObject.tag == "Spacedoor" && SceneManager.GetActiveScene().name == "Nexus")
        {
            SceneManager.LoadScene("spacelevel");


            if (coll.gameObject.tag == "SpaceDoor")
            {
                SceneManager.LoadScene("spaceLevel");

            }
        }
        


    }







    public void OnResetButton()
    {
        /*
        print("I hit the reset button!!!!!!");
        for (int i = 0; i < platforms.Length; i++)
        {
            platforms[i].SetActive(false);
            platforms[i].transform.position = temp[i].transform.position;
            platforms[i].SetActive(true);
        }
        */

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;

    }
    void Update()
    {
        if(numKeys == 1 && SceneManager.GetActiveScene().name == "Tutorial")
        {
            print("Tutorial level part1 finished");
            beginningWall.SetActive(false);
        }
        if (numKeys == 2 && (SceneManager.GetActiveScene().name == "Tutorial"))
        {
            secondWall.SetActive(false);
        }
        if (numKeys == 3 && (SceneManager.GetActiveScene().name == "Tutorial"))
        {
            a.SetActive(false);
        }
        if (numKeys == 2 && !(SceneManager.GetActiveScene().name == "Tutorial"))
        {
           
            if (a != null)

                Destroy(a);

            if (b != null)
            {
                b.SetActive(true);
            }

            if(a!= null)
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




   


