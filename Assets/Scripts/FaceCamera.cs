using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceCamera : MonoBehaviour
{
    private Transform cam;
    private Vector3 lastPosition;


    void Start()
    {
        cam = Camera.main.transform;
    }

    void LateUpdate()
    {
        Vector3 lookDirection = cam.position - transform.position;
        lookDirection.y = 0; 
        if (lookDirection != Vector3.zero)
        {
            transform.forward = lookDirection.normalized;
        }
    }
}
