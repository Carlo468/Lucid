﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameController : MonoBehaviour {

    // Use this for initialization
    public Transform SpawnPoint;
    public Transform SpawnPointFloor;
    private RaycastHit rayHit;
    public LayerMask layerMask;
    public float rayLength;

    public ParticleSystem ps;
    public static bool forestLevel = false;
    public static bool desertLevel = false;
    public static bool spaceLevel = false;

    Transform startPos;
    void Start () {
        startPos = transform;
		
	}
	
	// Update is called once per frame
	void Update () {

        


        Debug.DrawRay(transform.position, transform.forward * rayLength, Color.red);

        if (Physics.Raycast(transform.position, transform.forward, out rayHit, rayLength, layerMask))
        {
           // ObjInteraction(rayHit.collider.gameObject);
            print("I hit " + rayHit.collider.gameObject.name);

            if (rayHit.collider.gameObject.tag == "key")
            {
                Debug.Log("Im looking at the key");
                if(Input.GetKeyDown(KeyCode.Mouse0))
                {
                    Player.numKeys++;
                    print("I have " + Player.numKeys + "keys");
                    spawnps(rayHit.collider.gameObject.transform);
                    Destroy(rayHit.collider.gameObject);
                }

            }

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

            if (Player.numKeys == 1 && SceneManager.GetActiveScene().Equals("spaceLevel"))
            {
                spaceLevel = true;
            }
        }

    }

    

    
    IEnumerator wait()
    {
        print(Time.time);
        yield return new WaitForSeconds(1);
        print(Time.time);
    }
    void spawnps(Transform position)
    {
        Instantiate(ps, position.position, position.rotation);
    }
    void playerRespawn()
    {
        
        gameObject.SetActive(false);
        transform.Translate(startPos.transform.position);
        gameObject.SetActive(true);
    }
}
