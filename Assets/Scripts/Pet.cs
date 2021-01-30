using UnityEngine;

public class Pet: MonoBehaviour
{
    private Owner owner;
    
    void Start()
    {
        
    }

    
    void SetOwner(Owner owner)
    {
        this.owner = owner;
    }
}
