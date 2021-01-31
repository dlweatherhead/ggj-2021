using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissingPetPoster : MonoBehaviour
{
    private DialogueScript dialogueScript;
    public Owner owner;
    public Pet pet;

    public PosterUIInformation posterThumbnail;

    void Start()
    {
        dialogueScript = GameObject.FindGameObjectWithTag("Dialogue").GetComponent<DialogueScript>();
    }

    public void ActivatePoster()
    {
        dialogueScript.SetText("Picked up missing pet poster");
        posterThumbnail.gameObject.SetActive(true);
        posterThumbnail.pet = pet;
        posterThumbnail.owner = owner;
        posterThumbnail.poster = this;
    }

}
