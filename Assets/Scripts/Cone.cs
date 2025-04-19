using UnityEngine;

public class Cone : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("IceCreamScoop"))
        {
            collision.transform.SetParent(this.transform);

            // Optional: make scoop stop moving
            Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.isKinematic = true;
            }
        }
    }
}
