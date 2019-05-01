using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VideoPlayer : MonoBehaviour
{
    GameObject endVideo;
    int currentTime;
    int endTime;
    void Start()
    {
        endVideo = GameObject.FindWithTag("endVideo");
        if(endVideo != null)
        {
            endVideo.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Player.endGame)
        {
            endVideo.SetActive(true);

            StartCoroutine(quickPause());

            

        }
    }

    IEnumerator quickPause()
    {
        Debug.Log("Let's wait a bit");

        yield return new WaitForSeconds(8);

        Debug.Log("Ok I've waited...do something!");


        Application.Quit();

    }
}
