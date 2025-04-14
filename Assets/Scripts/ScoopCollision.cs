using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class VRGrabScoop : MonoBehaviour
{
    public Transform iceCreamBall; // Reference to the ice cream ball
    private Rigidbody scoopRigidbody;
    private XRGrabInteractable grabInteractable;  // XRGrabInteractable component
    private bool isGrabbed = false;

    private void Start()
    {
        scoopRigidbody = GetComponent<Rigidbody>();
        grabInteractable = GetComponent<XRGrabInteractable>(); // Get the grab interactable component
    }

    private void OnEnable()
    {
        // Ensure that grab events are subscribed to
        grabInteractable.onSelectEntered.AddListener(OnGrabbed);
        grabInteractable.onSelectExited.AddListener(OnReleased);
    }

    private void OnDisable()
    {
        grabInteractable.onSelectEntered.RemoveListener(OnGrabbed);
        grabInteractable.onSelectExited.RemoveListener(OnReleased);
    }

    private void OnGrabbed(XRBaseInteractor interactor)
    {
        Debug.Log("Scoop grabbed by: " + interactor.gameObject.name);
        isGrabbed = true;
        scoopRigidbody.isKinematic = true; // Make the scoop non-affected by physics when grabbed
        transform.SetParent(interactor.transform); // Parent to the controller
    }

    private void OnReleased(XRBaseInteractor interactor)
    {
        Debug.Log("Scoop released by: " + interactor.gameObject.name);
        isGrabbed = false;
        scoopRigidbody.isKinematic = false; // Re-enable physics once released
        transform.SetParent(null); // Unparent it from the controller
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (isGrabbed && collision.gameObject.CompareTag("IceCreamBall"))
        {
            Debug.Log("Scoop collided with the Ice Cream Ball.");
            // Attach the scoop to the ball
            AttachScoopToBall(collision.transform);
        }
    }

    private void AttachScoopToBall(Transform ball)
    {
        // Parent the scoop to the ball
        transform.SetParent(ball);

        // Optionally, disable the scoop's Rigidbody if you want it to be controlled by the ball
        scoopRigidbody.isKinematic = true;

        // Adjust position and rotation of scoop to align correctly on the ball
        transform.localPosition = new Vector3(0f, 0.5f, 0f);  // Modify this based on desired position
        transform.localRotation = Quaternion.identity;         // Adjust rotation as needed
    }
}
