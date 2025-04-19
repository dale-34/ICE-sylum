using UnityEngine;

public class IceCreamScoop : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("IceCreamBall"))
        {
            // Parent the ice cream to the scoop
            collision.transform.SetParent(this.transform);

            // Optional: disable rigidbody so it doesn't fall off
            Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.isKinematic = true;
            }
        }
    }
}
