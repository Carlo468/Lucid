using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nexus : MonoBehaviour
{
    GameObject woodDoor;
    GameObject desertDoor;
    GameObject spaceDoor;
    // Start is called before the first frame update
    void Start()
    {
        woodDoor = GameObject.FindWithTag("woodDoor");
        desertDoor = GameObject.FindWithTag("desertDoor");
        spaceDoor = GameObject.FindWithTag("spaceDoor");
    }

    // Update is called once per frame
    void Update()
    {
        if (LevelProgression.level2 == true)
        {
            desertDoor.SetActive(true);
        }
        else
            desertDoor.SetActive(false);

        if (LevelProgression.level3 == true)
        {
            spaceDoor.SetActive(true);
        }
        else
            spaceDoor.SetActive(false);
    }
}
