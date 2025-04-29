using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteFlip : MonoBehaviour
{
    public GameObject frontSprite;
    public GameObject backSprite;
    public Transform cameraTransform;

    void Update()
    {
        Vector3 toCamera = cameraTransform.position - transform.position;
        Vector3 forward = transform.forward;

        // Determine if the camera is in front of the sprite
        bool isFront = Vector3.Dot(forward, toCamera) < 0;

        frontSprite.SetActive(isFront);
        backSprite.SetActive(!isFront);
    }

}
