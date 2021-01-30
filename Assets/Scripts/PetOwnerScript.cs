using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetOwnerScript : MonoBehaviour
{

    private DialogueScript dialogueScript;

    private void Start()
    {
        dialogueScript = GameObject.FindObjectOfType<DialogueScript>();
    }

    public void ReturnPet(GameObject pet)
    {
        dialogueScript.SetText("That's not my pet!");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
