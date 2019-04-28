using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    bool paused;
    GameObject pauseMenu;
    GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        pauseMenu = GameObject.FindWithTag("Pause");

        Player = GameObject.FindWithTag("Player");
        if (pauseMenu != null)
            pauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            Time.timeScale = 0;
            pauseMenu.SetActive(true);
            Player.gameObject.SetActive(false);
            Cursor.lockState = CursorLockMode.None;
            //Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
            
            if (paused == true)
            {
                Time.timeScale = 1;
                pauseMenu.SetActive(false);
                Player.gameObject.SetActive(true);
                paused = false;
                return;
            }
            paused = true;

        }
    }
}
