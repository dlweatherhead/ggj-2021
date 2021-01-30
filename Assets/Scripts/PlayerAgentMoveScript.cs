using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(PickupScript))]
public class PlayerAgentMoveScript : MonoBehaviour
{

    private NavMeshAgent navMeshAgent;
    private PickupScript pickupScript;
    
    void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        pickupScript = GetComponent<PickupScript>();
    }
  
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity))
            {
                GameObject o = hit.transform.gameObject;
                if (o.CompareTag("Pet"))
                {
                    Debug.Log("Picking up Pet");
                    pickupScript.PickupObject(o);
                } else if (o.CompareTag("Ground"))
                {
                    Debug.Log("Moving to location " + o.transform.position);
                    navMeshAgent.destination = hit.point;
                }
                
            }
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            pickupScript.DropObject();
        }
    }
}
