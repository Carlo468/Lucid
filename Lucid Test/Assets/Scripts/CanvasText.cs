using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CanvasText : MonoBehaviour
{
    public Text numKeysText;
    int numKeysForScene;
    // Start is called before the first frame update
    void Start()
    {
        //numKeysText = GameObject.FindObjectOfType<Text>();


        if(SceneManager.GetActiveScene().name == "Tutorial")
        {
            numKeysForScene = 7;
        }
        if (SceneManager.GetActiveScene().name == "Desert")
        {
            numKeysForScene = 6;
        }
        if (SceneManager.GetActiveScene().name == "forestLevel")
        {
            numKeysForScene = 4;
        }
        if (SceneManager.GetActiveScene().name == "spaceLevel")
        {
            numKeysForScene = 2;
        }
    }

    // Update is called once per frame
    void Update()
    {
        numKeysText.text = "Num. Keys: " + Player.numKeys + "/" + numKeysForScene; 
    }
}
