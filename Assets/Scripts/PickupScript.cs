using UnityEngine;

public class PickupScript : MonoBehaviour
{
    public float pickupRadius = 2.5f;
    public Transform holdingPosition;

    private GameObject pickedUpObject;

    public void PickupObject(GameObject o)
    {
        if (pickedUpObject != null)
        {
            DropObject();
        }

        if(Vector3.Distance(o.transform.position, transform.position) < pickupRadius)
        {
            o.transform.position = holdingPosition.transform.position;
            o.transform.SetParent(gameObject.transform);
            pickedUpObject = o;
        } else
        {
            Debug.Log("Object too far away.");
        }
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

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, pickupRadius);
    }
}
