using UnityEngine;

public class CameraFollowScript : MonoBehaviour
{
    public GameObject player;

    private Vector3 originalPosition;

    void Start()
    {
        originalPosition = transform.position;
    }

    void Update()
    {
        var newPos = player.transform.position + originalPosition;
        transform.position = newPos;
    }
}
