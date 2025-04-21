using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoScoops : MonoBehaviour
{
    public Transform attachTo; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("IceCreamBall"))
        {
            Transform ball = other.transform;

            // Unparent from scoop
            ball.SetParent(null);

            // Attach to First Ice Cream Scoop
            ball.SetParent(attachTo);
            ball.localPosition = Vector3.zero;
            ball.localRotation = Quaternion.Euler(0, 180, 0);
        }
    }
}
