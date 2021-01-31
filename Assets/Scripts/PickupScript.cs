using UnityEngine;
using TMPro;

[RequireComponent(typeof(AudioSource))]
public class PickupScript : MonoBehaviour
{
    public float pickupRadius = 2.5f;
    public Transform holdingPosition;

    public AudioClip[] catMeows;

    private AudioSource audioSource;

    private DialogueScript dialogueScript;

    private GameObject pickedUpObject;


    private void Start()
    {
        dialogueScript = FindObjectOfType<DialogueScript>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Meow()
    {
        var clip = catMeows[Random.Range(0, catMeows.Length)];
        audioSource.clip = clip;
        audioSource.Play();
    }

    public void PickupObject(GameObject o)
    {
        Meow();

        if (pickedUpObject != null)
        {
            DropObject();
        }

        o.transform.position = holdingPosition.transform.position;
        o.transform.SetParent(gameObject.transform);
        pickedUpObject = o;
    }

    public GameObject GetPickedUpObject()
    {
        return pickedUpObject;
    }

    public void DropObject()
    {
        if (pickedUpObject != null)
        {
            Meow();

            pickedUpObject.transform.SetParent(null);
            var newPos = pickedUpObject.transform.position;
            pickedUpObject.transform.position = new Vector3(
                newPos.x + Random.Range(-1f, 1f),
                0f,
                newPos.z + Random.Range(-1f, 1f));
            pickedUpObject = null;
        }
    }

    public void DropObject(Vector3 destination)
    {
        if (pickedUpObject != null)
        {
            pickedUpObject.transform.SetParent(null);
            pickedUpObject.transform.position = new Vector3(destination.x, 0f, destination.z);
            pickedUpObject = null;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, pickupRadius);
    }
}
