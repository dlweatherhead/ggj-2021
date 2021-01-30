using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissingPetPoster : MonoBehaviour
{
    private DialogueScript dialogueScript;

    void Start()
    {
        dialogueScript = GameObject.FindGameObjectWithTag("Dialogue").GetComponent<DialogueScript>();
    }

    public void ActivatePoster()
    {
        dialogueScript.SetText("Picked up missing pet poster");
    }

}
