using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unlock : MonoBehaviour {

    public ParticleSystem ps;

    public AudioSource soundPlayer;

    public AudioClip keySound;

    [Range(0.0f, 1.0f)]
    public float keyPickUpVolume;
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
            soundPlayer.PlayOneShot(keySound, keyPickUpVolume);
            Instantiate(ps, transform.position, transform.rotation);
            Destroy(collider.gameObject);
            Destroy(gameObject);
        }
    }
}
