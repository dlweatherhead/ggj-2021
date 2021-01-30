using UnityEngine;

public class PetSpawner : MonoBehaviour
{
    public GameObject[] petsToCreate;

    void Start()
    {
        SpawnAllPets();
    }

    void SpawnAllPets()
    {
        var potentialPetLocations = GameObject.FindGameObjectsWithTag("PotentialPet");

        foreach(GameObject pet in petsToCreate)
        {
            var randomPotentialPet = potentialPetLocations[Random.Range(0, potentialPetLocations.Length)];
            var p = Instantiate(pet, randomPotentialPet.transform);
        }
    }
    
}

