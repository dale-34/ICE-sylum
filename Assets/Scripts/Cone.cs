using UnityEngine;

public class Cone : MonoBehaviour
{
    public Transform attachTo; // Drag cone or a mount point

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("IceCreamBall"))
        {
            Transform ball = other.transform;

            // Unparent from scoop
            ball.SetParent(null);

            // Reparent to cone
            ball.SetParent(attachTo);
            ball.localPosition = Vector3.zero;
            ball.localRotation = Quaternion.Euler(0, 180, 0);

            

            // Optional: Disable collider / physics
            Rigidbody rb = ball.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.velocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
                rb.isKinematic = true;
            }

            Collider col = ball.GetComponent<Collider>();
            if (col != null) col.enabled = false;

            Debug.Log("Ball stuck to cone via trigger.");
        }
    }
}
