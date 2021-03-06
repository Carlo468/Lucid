﻿using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


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
    Material cubeCurMat;
    public Material grabMat;
    public Material transparentMaterial;

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
    Behaviour halo;
    public AudioSource soundPlayer;

    public AudioClip keySound;

    [Range(0.0f, 1.0f)]
    public float keyPickUpVolume;


    //public AudioSource soundPlayer;
    public AudioClip explosiveSound;

    [Range(0.0f, 1.0f)]
    public float explosiveVolume;

    public Text help;

    //public ParticleSystem ps;
    void Start () {
        startPos = transform;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (grab)
        {
            //gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY| RigidbodyConstraints.FreezePositionZ;

            //objectToMove.transform.Translate(0, Input.mouseScrollDelta.y * Time.deltaTime * moveSpeed, 0);
            
            if (Input.GetKey(KeyCode.Q))
                objectToMove.transform.Translate(0, 1 * Time.deltaTime * moveSpeed, 0);
            if (Input.GetKey(KeyCode.E))
                objectToMove.transform.Translate(0, -1 * Time.deltaTime * moveSpeed, 0);
           /*
            if (Input.GetKey(KeyCode.J))
                objectToMove.transform.Translate(-1 * Time.deltaTime * moveSpeed, 0, 0);
            if (Input.GetKey(KeyCode.L))
                objectToMove.transform.Translate( 1 * Time.deltaTime * moveSpeed, 0 , 0);
                */
                
        }
        ///////////////////test!///////////////////////////////////////////////
        
        //////////////////////////////////////////////////////////////////////

        if (Input.GetKeyDown(KeyCode.Mouse0) && objectToMove != null)
        {
            //objectToMove.transform.GetChild(0).GetComponent<Renderer>().material = curMat;
            objectToMove.GetComponent<Renderer>().material = curMat;
            grab = false;
        }

        
        if (Physics.Raycast(transform.position, transform.forward, out rayHit, rayLength, layerMask))
        {
            if (help != null)
            {
                if (rayHit.collider.gameObject.tag != "platformGrab" || rayHit.collider.gameObject.tag != "Grab" || rayHit.collider.gameObject.tag != "key")
                {
                    print("looking at nothing");
                    help.text = "";
                }
            }
            #region PlatformManipulationMechanic
            if (rayHit.collider.gameObject.tag == "platformGrab")
            {
                rayHit.collider.gameObject.transform.Rotate(new Vector3(0, 0, 0) * Time.deltaTime);

                //Highlight it!
                halo = (Behaviour)rayHit.collider.gameObject.GetComponent("Halo");
                halo.enabled = true;

                if(help != null)
                {
                    help.text = "Interactable platform: 'Q' moves the platform up. 'E' moves the platform down.";
                }

                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    if (grab)
                    {
                        //objectToMove.transform.GetChild(0).GetComponent<Renderer>().material = curMat;
                        //objectToMove = null;
                        //grab = false;
                        objectToMove.GetComponent<Renderer>().material = curMat;
                        grab = false;
                        return;
                    }
                    
                    Debug.Log("grabbing the platform");



                    //objectToMove = rayHit.collider.gameObject.transform.parent.gameObject;
                    objectToMove = rayHit.collider.gameObject;


                    //curMat = objectToMove.transform.GetChild(0).GetComponent<Renderer>().material;
                    curMat = objectToMove.GetComponent<Renderer>().material;
                    //print( "Child: " +objectToMove.transform.GetChild(0).gameObject.name);

                    //objectToMove.transform.GetChild(0).GetComponent<Renderer>().material = grabMat;
                    objectToMove.GetComponent<Renderer>().material = grabMat;
                    //objectToMove.GetComponent<Light>().intensity = 44;



                    // if (objectToMove.GetComponent<Renderer>().material == grabMat)
                    grab = true;

                }
                /*
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {

                    //objectToMove.transform.GetChild(0).GetComponent<Renderer>().material = curMat;
                    objectToMove.GetComponent<Renderer>().material = curMat;

                    grab = false;
                }
                */
                if (Input.GetKeyDown(KeyCode.Mouse2))
                {
                    objectToMove.transform.Rotate(0, 0, 90);
                }
                
            }
            //help.text = "";

            if ((!(rayHit.collider.gameObject.tag == "platformGrab")) && rayHit.collider.gameObject != null && halo != null)
            {
                halo.enabled = false;
            }


            #endregion
            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            #region throwableCubeMechanic
            if (rayHit.collider.gameObject.tag == "Grab")
            {
                //float savedDistance;
                rayHit.collider.gameObject.transform.Rotate(new Vector3(0, 30, 0) * Time.deltaTime);
               

                GameObject objectToMove = rayHit.collider.gameObject;
                

                throwObj = rayHit.collider.gameObject;

                if (help != null)
                {
                    help.text = "Throw-able Cube: Right click to grab, Press down on the mouse scroll wheel to throw";
                }
                //objPos = rayHit.collider.gameObject.transform;

                if (objectToMove.transform.parent != null && Input.GetKeyDown(KeyCode.Mouse2))
                {
                    Debug.Log("Throw!");
                    
                    
                    rayHit.collider.gameObject.transform.parent = null;

                    spawnps(rayHit.collider.gameObject.transform);
                    soundPlayer.PlayOneShot(explosiveSound, explosiveVolume);

                    objectToMove.GetComponent<Rigidbody>().AddForce(Camera.main.transform.forward* Force);
                    Debug.Log("Turning the color");
                    throwObj.GetComponent<Renderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
                    //respawnObj();

                }

                if (Input.GetKeyDown(KeyCode.Mouse1))
                {
                    
                    Debug.Log("I'm grabbing the object!");
                    respawnObj();
                    rayHit.collider.gameObject.GetComponent<Light>().gameObject.SetActive(true);
                    rayHit.collider.gameObject.transform.parent = transform;
                    objectToMove.gameObject.GetComponent<Renderer>().material = transparentMaterial;
                    
                }

                

                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    Debug.Log("ungrabbing!");
                    rayHit.collider.gameObject.transform.parent = null;
                }


                }

            
            #endregion


            print("I hit " + rayHit.collider.gameObject.name);

            if (rayHit.collider.gameObject.tag == "key")
            {
                Debug.Log("Im looking at the key");
                if (help != null)
                {
                    help.text = "Key: Left click to grab";
                }
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    Player.numKeys++;
                    soundPlayer.PlayOneShot(keySound, keyPickUpVolume);
                    
                    print("I have " + Player.numKeys + "keys");
                    spawnps(rayHit.collider.gameObject.transform);
                    Destroy(rayHit.collider.gameObject);
                }

            }
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
           
            if (rayHit.collider.gameObject.tag == "woodDoor" && Player.numKeys == 4)
            {
                Debug.Log("I hit the wood door!");
                forestLevel = true;
                Player.numKeys = 0;
            }

            if (rayHit.collider.gameObject.tag == "DesertDoor" && Player.numKeys == 6)
            {
                Debug.Log("I hit the Desert door!");
                desertLevel = true;
                Player.numKeys = 0;
            }

           
    }

        if (Player.numKeys == 1 && SceneManager.GetActiveScene().name.Equals("spaceLevel"))
        {
            spaceLevel = true;
        }
        //Debug.Log(SceneManager.GetActiveScene().name);
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
