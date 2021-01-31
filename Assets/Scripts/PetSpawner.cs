using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetSpawner : MonoBehaviour
{
    public GameObject[] petsToCreate;

    private Owner[] owners;

    void Start()
    {
        owners = FindObjectsOfType<Owner>();

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

        foreach(GameObject pet in petsToCreate)
        {
            var randomPotentialPet = locations[Random.Range(0, locations.Count)];
            locations.Remove(randomPotentialPet);
            var p = Instantiate(pet, randomPotentialPet.transform);

            var randomOwner = Random.Range(0, owners.Length);

            owners[randomOwner].AddPet(p.name);
        }
    }
    
}

