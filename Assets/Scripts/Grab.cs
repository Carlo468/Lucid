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

    public int Force;
    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        
        if (Physics.Raycast(transform.position, transform.forward, out rayHit, rayLength, layerMask))
        {
            if (rayHit.collider.gameObject.tag == "Grab")
            {
                //float savedDistance;
                rayHit.collider.gameObject.transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);

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

    void OnMouseDown()
    {
        screenPoint = Camera.main.WorldToScreenPoint(Input.mousePosition);
        offset = Input.mousePosition - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z));
    }
    void Drag(GameObject go)
    {
        
    }

    void OnMouseDrag()
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z);
        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
        transform.position = curPosition;
        

    }
    void respawnObj()
    {
        Instantiate(throwObj, objThrowPos.transform.transform.position, objThrowPos.transform.rotation);
    }
}
