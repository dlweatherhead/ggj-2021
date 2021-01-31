using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetSpawner : MonoBehaviour
{
    public GameObject[] petsToCreate;

    private Owner[] owners;
    private MissingPetPoster[] missingPetPosters;

    void Start()
    {
        owners = FindObjectsOfType<Owner>();
        missingPetPosters = FindObjectsOfType<MissingPetPoster>();

        SpawnAllPets();
    }

    void SpawnAllPets()
    {
        GameObject[] potentialPetLocations = GameObject.FindGameObjectsWithTag("PotentialPet");
        List<GameObject> locations = new List<GameObject>();

        foreach(GameObject location in potentialPetLocations)
        {
            locations.Add(location);
        }

        List<MissingPetPoster> posters = new List<MissingPetPoster>();
        foreach(MissingPetPoster poster in missingPetPosters)
        {
            posters.Add(poster);
        }

        foreach(GameObject pet in petsToCreate)
        {
            var randomPotentialPet = locations[Random.Range(0, locations.Count)];
            locations.Remove(randomPotentialPet);

            var p = Instantiate(pet, randomPotentialPet.transform).GetComponent<Pet>();

            var o = owners[Random.Range(0, owners.Length)];
            var randomPoster = posters[Random.Range(0, posters.Count)];
            posters.Remove(randomPoster);

            o.AddPet(p);

            p.owner = o;
            p.poster = randomPoster;

            randomPoster.owner = o;
            randomPoster.pet = p;
        }
    }
    
}

