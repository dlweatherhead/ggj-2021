using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSwitch : MonoBehaviour
{
    public GameObject boy;
    public GameObject girl;
    public CameraFollowScript cameraFollow;

    void Awake()
    {
        var p = PlayerPrefs.GetInt("Player");
        if(p == 0)
        {
            boy.SetActive(true);
            cameraFollow.player = boy;
            Destroy(girl);
        } else
        {
            girl.SetActive(true);
            cameraFollow.player = girl;
            Destroy(boy);
        }

        Destroy(gameObject);
    }
}
