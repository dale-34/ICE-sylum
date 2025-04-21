using UnityEngine;

public class Cone : MonoBehaviour
{
    public Transform attachTo; 
    bool firstScoop = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("IceCreamBall") && !firstScoop)
        {
            Transform ball = other.transform;

            // Unparent from scoop
            ball.SetParent(null);

            // Attach to Cone
            ball.SetParent(attachTo);
            ball.localPosition = Vector3.zero;
            ball.localRotation = Quaternion.Euler(0, 180, 0);

            Rigidbody rb = ball.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.velocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
                rb.isKinematic = true;
            }

            Collider col = ball.GetComponent<Collider>();
            if (col != null) col.enabled = false;
            firstScoop = true;
        }
    }
}
