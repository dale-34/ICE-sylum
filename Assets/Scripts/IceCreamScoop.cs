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
            collision.transform.localRotation = Quaternion.identity; // optional

            Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.isKinematic = true;
            }

            Debug.Log("Ice cream ball snapped to scoop.");
        }
    }
}
