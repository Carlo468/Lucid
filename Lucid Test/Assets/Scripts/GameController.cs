using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    // Use this for initialization
    public Transform SpawnPoint;
    public Transform SpawnPointFloor;
    private RaycastHit rayHit;
    public LayerMask layerMask;
    public float rayLength;

    public ParticleSystem ps;
    void Start () {

		
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
}
