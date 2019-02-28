using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnWall : MonoBehaviour {

    // Use this for initialization
    public Transform SpawnPoint;
    public Transform SpawnPointFloor;

    public GameObject pw;
    public GameObject pl;
    private static bool wallPlaced;
    private static bool floorPlaced;


    private RaycastHit rayHit;
    public LayerMask layerMask;
    public float rayLength;

    public ParticleSystem ps;
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if(Input.GetKeyDown(KeyCode.Q) && wallPlaced == false)
        {
            Debug.Log("placing down a wall");
            spawnpw();
            wallPlaced = true;
            StartCoroutine(wait());
        }


        if (Input.GetKeyDown(KeyCode.Z) && wallPlaced == false)
        {
            Debug.Log("placing down a wall");
            spawnpl();
            wallPlaced = true;
            StartCoroutine(wait());
        }

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
            if (rayHit.collider.gameObject.tag == "PlayerWall" )
            {
                Debug.Log("Im looking at my wall");
                
                if(Input.GetKeyDown(KeyCode.E))
                {
                    Destroy(rayHit.collider.gameObject);
                    Debug.Log("it has been destroyed!");
                    wallPlaced = false;
                }
            }

            if (rayHit.collider.gameObject.tag == "PlayerFloor")
            {
                Debug.Log("Im looking at my floor");

                if (Input.GetKeyDown(KeyCode.E))
                {
                    Destroy(rayHit.collider.gameObject);
                    Debug.Log("it has been destroyed!");
                    wallPlaced = false;
                }
            }
        }

    }

    void spawnpw()
    {
        Instantiate(pw, SpawnPoint.transform.position, SpawnPoint.transform.rotation);
    }

    void spawnpl()
    {
        Instantiate(pl, SpawnPointFloor.transform.position, SpawnPointFloor.transform.rotation);
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
}
