using System.Collections;
using System.Collections.Generic;
using UnityEngine;


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
    public int Force;
    public float moveSpeed;

    //public Light light;
    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        
        if (Physics.Raycast(transform.position, transform.forward, out rayHit, rayLength, layerMask))
        {

            if(rayHit.collider.gameObject.tag == "platformGrab")
            {
                rayHit.collider.gameObject.transform.Rotate(new Vector3(0, 0, 0) * Time.deltaTime);
                rayHit.collider.gameObject.GetComponent<Light>().gameObject.SetActive(true);

                

                if (Input.GetKeyDown(KeyCode.Mouse1))
                {
                    
                    Debug.Log("I'm saving the platform!");
                    rayHit.collider.gameObject.GetComponent<Light>().gameObject.SetActive(true);

                    objectToMove = rayHit.collider.gameObject;

                    objectToMove.GetComponent<Renderer>().material = grabMat;


                    //rayHit.collider.gameObject.transform.parent = transform;
                    Debug.Log("x: " +Input.mouseScrollDelta.x);
                    Debug.Log("y: " +Input.mouseScrollDelta.y);

                    


                    /*
                    GameObject objectToMove = rayHit.collider.gameObject;
                    objectToMove.GetComponent<Renderer>().material = grabMat;
                    transform.
                    if(Input.GetKey(KeyCode.W))
                    {
                        objectToMove.transform.Translate(Vector3.up * Time.deltaTime);
                    }
                    */

                }


               

                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    Debug.Log("detatching!");
                    objectToMove.GetComponent<Renderer>().material = null;
                    objectToMove = null;
                }
               
                if(Input.GetKeyDown(KeyCode.Mouse2))
                {
                    Debug.Log("Rotating");
                    objectToMove.transform.Rotate(0, 0, 90);
                }
                



            }

            if (objectToMove != null)
            {
                objectToMove.transform.Translate(0, Input.mouseScrollDelta.y * moveSpeed * Time.deltaTime, 0);
            }

            if (rayHit.collider.gameObject.tag == "Grab")
            {
                //float savedDistance;
                rayHit.collider.gameObject.transform.Rotate(new Vector3(0, 30, 0) * Time.deltaTime);
                rayHit.collider.gameObject.GetComponent<Light>().gameObject.SetActive(true);

                GameObject objectToMove = rayHit.collider.gameObject;
                throwObj = rayHit.collider.gameObject;
                //objPos = rayHit.collider.gameObject.transform;

                if (objectToMove.transform.parent != null && Input.GetKeyDown(KeyCode.Mouse2))
                {
                    Debug.Log("Throw!");
                    
                    
                    rayHit.collider.gameObject.transform.parent = null;
                    objectToMove.GetComponent<Rigidbody>().AddForce(Camera.main.transform.forward * Force);
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
        }
    }

   
    void respawnObj()
    {
        Instantiate(throwObj, objThrowPos.transform.transform.position, objThrowPos.transform.rotation);
    }
}
