using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(PickupScript))]
public class PlayerAgentMoveScript : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;
    private PickupScript pickupScript;

    public Animator animator;

    public float interactionRadius = 2.5f;
    
    void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        pickupScript = GetComponent<PickupScript>();
    }
  
    void Update()
    {
        animator.SetBool("isRunning", navMeshAgent.hasPath);

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
                } else if (o.CompareTag("MissingPoster"))
                {
                    Debug.Log("Picking up missing poster");
                    o.GetComponent<MissingPetPoster>().ActivatePoster();
                    o.SetActive(false);
                } else if (o.CompareTag("Owner"))
                {
                    Debug.Log("Clicked on owner door");
                    o.GetComponent<PetOwnerScript>().ReturnPet(null);
                    pickupScript.DropObject(o.transform.position);
                }
                
            }
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            pickupScript.DropObject();
        }
    }
}
