using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSLimiter : MonoBehaviour
{
    [Range(10, 100)]
    public int targetFramerate = 30;

    void Start()
    {
        Application.targetFrameRate = targetFramerate;
    }
}
