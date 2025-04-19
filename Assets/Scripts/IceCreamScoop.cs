using UnityEngine;

public class IceCreamScoop : MonoBehaviour
{
    public Transform scoopAttachPoint;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("IceCreamBall"))
        {
            collision.transform.SetParent(scoopAttachPoint);
            collision.transform.localPosition = Vector3.zero;

            // Optional: disable rigidbody so it doesn't fall off
            Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.isKinematic = true;
            }
        }
    }
}
