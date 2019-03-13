using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Levels : MonoBehaviour
{
    // Start is called before the first frame update
    bool desert;
    bool forest;
    bool space;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameController.desertLevel == true)
        {
            desert = true;
        }

        if (GameController.forestLevel == true)
        {
            forest = true;
        }

        if (GameController.spaceLevel == true)
        {
            space = true;
        }
    }
}
