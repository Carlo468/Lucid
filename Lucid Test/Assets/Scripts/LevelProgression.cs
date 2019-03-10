using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelProgression : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Player.numKeys == 7)
        {
            Debug.Log("Seven keys have been met, traveling to nexus");
            SceneManager.LoadScene("Nexus");
        }
              
    }
}
