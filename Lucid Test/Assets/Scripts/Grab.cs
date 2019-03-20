using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Grab : MonoBehaviour {

    private RaycastHit rayHit;
    public LayerMask layerMask;
    public float rayLength;

    private Vector3 screenPoint;
    private Vector3 offset;

    Transform scanPos;

    public Transform objThrowPos;
    GameObject throwObj;
    Material curMat;
    public Material grabMat;
    GameObject objectToMove;
    bool grab = false;

    public int Force;
    public int moveSpeed;

    //public Light light;
    // Use this for initialization

    public ParticleSystem ps;
    public static bool tutorialLevel = false;
    public static bool forestLevel = false;
    public static bool desertLevel = false;
    public static bool spaceLevel = false;
    public Transform startPos;
    //public ParticleSystem ps;
    void Start () {
        startPos = transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (grab)
        {
            objectToMove.transform.Translate(0, Input.mouseScrollDelta.y * Time.deltaTime * moveSpeed, 0);
        }

        if (Physics.Raycast(transform.position, transform.forward, out rayHit, rayLength, layerMask))
        {

            if(rayHit.collider.gameObject.tag == "platformGrab")
            {
                rayHit.collider.gameObject.transform.Rotate(new Vector3(0, 0, 0) * Time.deltaTime);
                
                if (Input.GetKeyDown(KeyCode.Mouse1))
                {
                    if (grab)
                    {
                        objectToMove.GetComponent<Renderer>().material = curMat;
                        objectToMove = null;
                        grab = false;
                    }
                    Debug.Log("grabbing the platform");


                    objectToMove = rayHit.collider.gameObject;

                    curMat = objectToMove.GetComponent<Renderer>().material;
                    objectToMove.GetComponent<Renderer>().material = grabMat;

                    // if (objectToMove.GetComponent<Renderer>().material == grabMat)
                    grab = true;

                }

                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    objectToMove.GetComponent<Renderer>().material = curMat;
                    grab = false;
                }
                
                if (Input.GetKeyDown(KeyCode.Mouse2))
                {
                    objectToMove.transform.Rotate(0, 0, 90);
                }

            }
 /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
           

            if (rayHit.collider.gameObject.tag == "Grab")
            {
                //float savedDistance;
                rayHit.collider.gameObject.transform.Rotate(new Vector3(0, 30, 0) * Time.deltaTime);
               

                GameObject objectToMove = rayHit.collider.gameObject;
                throwObj = rayHit.collider.gameObject;
                //objPos = rayHit.collider.gameObject.transform;

                if (objectToMove.transform.parent != null && Input.GetKeyDown(KeyCode.Mouse2))
                {
                    Debug.Log("Throw!");
                    
                    
                    rayHit.collider.gameObject.transform.parent = null;
                    objectToMove.GetComponent<Rigidbody>().AddForce(Camera.main.transform.forward* Force);
                    respawnObj();

                }

                if (Input.GetKeyDown(KeyCode.Mouse1))
                {
                    
                    Debug.Log("I'm grabbing the object!");
                    rayHit.collider.gameObject.GetComponent<Light>().gameObject.SetActive(true);
                    rayHit.collider.gameObject.transform.parent = transform;
                    
                    
                }

                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    Debug.Log("ungrabbing!");
                    rayHit.collider.gameObject.transform.parent = null;
                }


                }

            print("I hit " + rayHit.collider.gameObject.name);

            if (rayHit.collider.gameObject.tag == "key")
            {
                Debug.Log("Im looking at the key");
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    Player.numKeys++;
                    print("I have " + Player.numKeys + "keys");
                    spawnps(rayHit.collider.gameObject.transform);
                    Destroy(rayHit.collider.gameObject);
                }

            }
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            if (rayHit.collider.gameObject.tag == "killbox")
            {
                Debug.Log("respawning");
                playerRespawn();
            }
            if (rayHit.collider.gameObject.tag == "woodDoor" && Player.numKeys == 3)
            {
                Debug.Log("I hit the wood door!");
                forestLevel = true;
            }

            if (rayHit.collider.gameObject.tag == "DesertDoor" && Player.numKeys == 6)
            {
                Debug.Log("I hit the Desert door!");
                desertLevel = true;
            }

           
    }

        if (Player.numKeys == 1 && SceneManager.GetActiveScene().name.Equals("spaceLevel"))
        {
            spaceLevel = true;
        }
        Debug.Log(SceneManager.GetActiveScene().name);
        if (Player.numKeys == 7 && SceneManager.GetActiveScene().name.Equals("Tutorial"))
        {
            tutorialLevel = true;
        }
    }

   
    void respawnObj()
    {
        Instantiate(throwObj, objThrowPos.transform.transform.position, objThrowPos.transform.rotation);
    }

    void playerRespawn()
    {

        gameObject.SetActive(false);
        transform.Translate(startPos.transform.position);
        gameObject.SetActive(true);
    }
    void spawnps(Transform position)
    {
        Instantiate(ps, position.position, position.rotation);
    }
}
