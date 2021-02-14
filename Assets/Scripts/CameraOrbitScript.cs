using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraOrbitScript : MonoBehaviour
{
    public Transform cameraJig;
    public float rotateSpeed;

    private void Start()
    {
        transform.LookAt(cameraJig);
        transform.RotateAround(cameraJig.position, Vector3.up, 0f);
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.LookAt(cameraJig);
            //transform.Translate(Vector3.right * Time.deltaTime);
            transform.RotateAround(cameraJig.position, Vector3.up, rotateSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.LookAt(cameraJig);
            //transform.Translate(-Vector3.right * Time.deltaTime);
            transform.RotateAround(cameraJig.position, -Vector3.up, rotateSpeed * Time.deltaTime);
        }
    }
}
