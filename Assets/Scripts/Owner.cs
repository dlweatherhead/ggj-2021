using System.Collections.Generic;
using UnityEngine;

public class Owner : MonoBehaviour
{
    private DialogueScript dialogueScript;

    public List<string> ownedPets;

    public Transform dropPlacement;

    private void Awake()
    {
        ownedPets = new List<string>();
    }

    private void Start()
    {
        dialogueScript = FindObjectOfType<DialogueScript>();
    }

    public void ReturnPet(string pet)
    {
        if(ownedPets.Contains(pet))
        {
            dialogueScript.SetText("Thank you so much!");
        }
        else
        {
            dialogueScript.SetText("That's not my pet!");
        }
    }

    public void AddPet(string pet)
    {
        ownedPets.Add(pet);
    }

}
