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
        if(Grab.tutorialLevel)
        {
            Debug.Log("Seven keys have been met, traveling to nexus");
            SceneManager.LoadScene("Nexus");
        }

        if (Grab.forestLevel == true)
        {
            SceneManager.LoadScene("Nexus");
        }

        if (Grab.desertLevel == true)
        {
            SceneManager.LoadScene("Nexus");
        }
        if(Grab.spaceLevel == true)
        {
            SceneManager.LoadScene("Nexus");

        }
    }
}
