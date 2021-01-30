using UnityEngine;

public class PickupScript : MonoBehaviour
{
    public float pickupRadius = 2f;
    public Transform holdingPosition;

    private GameObject pickedUpObject;

    public void PickupObject(GameObject o)
    {
        if(o == pickedUpObject)
        {
            pickedUpObject.transform.parent = null;
            var newPos = pickedUpObject.transform.position;
            pickedUpObject.transform.position = new Vector3(
                newPos.x + Random.Range(-1f, 1f),
                0f,
                newPos.z + Random.Range(-1f, 1f));
            return; 
        }

        if(Vector3.Distance(o.transform.position, transform.position) < pickupRadius)
        {
            o.transform.position = holdingPosition.transform.position;
            o.transform.parent = gameObject.transform;            
        } else
        {
            Debug.Log("Object too far away.");
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, pickupRadius);
    }
}
