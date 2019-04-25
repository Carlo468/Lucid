using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelProgression : MonoBehaviour
{
    public static bool level1;
    public static bool level2;
    public static bool level3;
    public static bool level4;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Grab.tutorialLevel && level1 == false)
        {
            Debug.Log("Seven keys have been met, traveling to nexus");
            SceneManager.LoadScene("Nexus");
            Player.numKeys = 0;
            Grab.tutorialLevel = false;
            level1 = true;
        }

        Debug.Log("forestLevel" + Grab.forestLevel);
        Debug.Log("tutorialLevel" + Grab.tutorialLevel);
        Debug.Log("desertLevel" + Grab.desertLevel);
        Debug.Log("spaceLevel" + Grab.forestLevel);

        if (Grab.forestLevel == true && level2 == false)
        {
            SceneManager.LoadScene("Nexus");
            level2 = true;
        }

        if (Grab.desertLevel == true && level3 == false)
        {
            SceneManager.LoadScene("Nexus");
            
            level3 = true;
            if (!level2)
            {
                level2 = true;
            }
        }
        if(Grab.spaceLevel == true && level4 == false)
        {
            SceneManager.LoadScene("Nexus");
            
            level4 = true;
        }
    }
}
