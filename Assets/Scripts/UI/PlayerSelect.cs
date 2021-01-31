using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelect : MonoBehaviour
{
    public GameObject boy;
    public GameObject girl;

    void Awake()
    {
        if(Random.Range(0, 2) == 0)
        {
            SelectBoy();
        } else
        {
            SelectGirl();
        }
    }


    public void SelectBoy()
    {
        boy.SetActive(true);
        girl.SetActive(false);
        PlayerPrefs.SetInt("Player", 0);
    }

    
    public void SelectGirl()
    {
        boy.SetActive(false);
        girl.SetActive(true);
        PlayerPrefs.SetInt("Player", 1);
    }
}
