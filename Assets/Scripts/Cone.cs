using UnityEngine;

public class Cone : MonoBehaviour
{
    public Transform attachTo; 
    public Transform attachTo2;
    bool firstScoop = false;

    public static int currentOrderInt = 0;

    // Blue : 1, Choc : 10, Strawberry: 100
    private void OnTriggerEnter(Collider other)
    {   
        if (other.CompareTag("Blue") || other.CompareTag("Choc") ||  other.CompareTag("Strawberry"))
        {
            Transform ball = other.transform;

            // Unparent from scoop
            ball.SetParent(null);

            // Attach to Cone
            if (!firstScoop)
            {
                ball.SetParent(attachTo);
            } 
            else {
                ball.SetParent(attachTo2);
            }

            if (other.CompareTag("Blue"))
            {
                currentOrderInt += 1;
            }
            else if (other.CompareTag("Choc"))
            {
                currentOrderInt += 10;
            }
            else if (other.CompareTag("Strawberry"))
            {
                currentOrderInt += 100;
            }

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
