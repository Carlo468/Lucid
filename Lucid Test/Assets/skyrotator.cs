using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skyrotator : MonoBehaviour
{

    public float RotateSpeed = 1.2f;
    void update()
    {
        RenderSettings.skybox.SetFloat("_Rotation", Time.time * RotateSpeed);
    }
}
