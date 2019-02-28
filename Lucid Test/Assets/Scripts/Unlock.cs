using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unlock : MonoBehaviour {

    public ParticleSystem ps;
    
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.tag == "Grab")
        {
            Debug.Log("I hit the button!");
            Player.numKeys++;
            Instantiate(ps, transform.position, transform.rotation);
            Destroy(collider.gameObject);
            Destroy(gameObject);
        }
    }
}
