using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Owner : MonoBehaviour
{
    private DialogueScript dialogueScript;

    public List<Pet> ownedPets;

    public Transform dropPlacement;

    public int houseNumber;

    public AudioClip[] negativeClips;
    public AudioClip successClip;
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
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
            pet.isFound = true;
            pet.GetComponent<BoxCollider>().enabled = false;

            audioSource.clip = successClip;
            audioSource.Play();
        }
        else
        {
            dialogueScript.SetText("That's not my pet!");
            audioSource.clip = negativeClips[Random.Range(0, negativeClips.Length)];
            audioSource.Play();
        }
    }

    public void AddPet(Pet pet)
    {
        ownedPets.Add(pet);
    }

}
