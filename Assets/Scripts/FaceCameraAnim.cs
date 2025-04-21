using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceCameraAnimator : MonoBehaviour
{
    private Animator animator;
    private Transform cam;
    private Vector3 lastPosition;

    public float speedThreshold = 0.01f; // Adjust if it’s too sensitive

    void Start()
    {
        cam = Camera.main.transform;
        animator = GetComponent<Animator>();
        lastPosition = transform.position;
    }

    void LateUpdate()
    {
        // Face the camera only on Y-axis (like a billboard)
        Vector3 lookDirection = cam.position - transform.position;
        lookDirection.y = 0; // Ignore vertical tilt
        if (lookDirection != Vector3.zero)
        {
            transform.forward = lookDirection.normalized;
        }

        // Check speed
        float speed = (transform.position - lastPosition).magnitude / Time.deltaTime;
        animator.SetFloat("Speed", speed > speedThreshold ? 1f : 0f);

        lastPosition = transform.position;
    }
}
