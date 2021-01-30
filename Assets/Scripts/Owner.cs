using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Owner : MonoBehaviour
{
    private DialogueScript dialogueScript;

    private List<Pet> ownedPets;

    private void Awake()
    {
        ownedPets = new List<Pet>();
    }

    private void Start()
    {
        dialogueScript = FindObjectOfType<DialogueScript>();
    }

    public void ReturnPet(Pet pet)
    {
        if(ownedPets.Contains(pet))
        {
            dialogueScript.SetText("Thank you so much!");
        }
        dialogueScript.SetText("That's not my pet!");
    }

    public void AddPet(Pet pet)
    {
        ownedPets.Add(pet);
    }

}
