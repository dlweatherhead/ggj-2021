using UnityEngine;
using TMPro;

public class PickupScript : MonoBehaviour
{
    public float pickupRadius = 2.5f;
    public Transform holdingPosition;

    private DialogueScript dialogueScript;

    private GameObject pickedUpObject;


    private void Start()
    {
        dialogueScript = FindObjectOfType<DialogueScript>();
    }

    public void PickupObject(GameObject o)
    {
        if (pickedUpObject != null)
        {
            DropObject();
        }

        o.transform.position = holdingPosition.transform.position;
        o.transform.SetParent(gameObject.transform);
        pickedUpObject = o;
    }

    public void DropObject()
    {
        if (pickedUpObject != null)
        {
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
