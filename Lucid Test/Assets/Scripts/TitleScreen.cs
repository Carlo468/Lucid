using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnStartButton()
    {
        SceneManager.LoadScene("Nexus");
        Grab.tutorialLevel = true;
        
    }

    public void OnTutorialButton()
    {
        SceneManager.LoadScene("Tutorial");
    }
    public void OnQuitButton()
    {
        Application.Quit(0);
    }
}
