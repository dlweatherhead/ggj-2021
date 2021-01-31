using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PosterUIInformation : MonoBehaviour
{
    public GameObject DetailParent;
    public TMP_Text HouseNumber;
    public Image PetPicture;

    public Pet pet;
    public MissingPetPoster poster;
    public Owner owner;

    public void ShowDetail()
    {
        HouseNumber.text = "House " + owner.houseNumber;
        PetPicture.sprite = pet.picture;
        DetailParent.SetActive(true);
    }
}
