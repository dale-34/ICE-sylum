using UnityEngine;

public class IceCreamScoop : MonoBehaviour
{
    public Transform scoopAttachPoint;
    public GameObject blueIceCreamPrefab;
    public GameObject pinkIceCreamPrefab;

    private GameObject currentIceCream; // so only one is on the scoop at a time

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("BlueContainer"))
        {
            AttachNewIceCream(blueIceCreamPrefab);
        }
        else if (collider.gameObject.CompareTag("PinkContainer"))
        {
            AttachNewIceCream(pinkIceCreamPrefab);
        }
    }

    private void AttachNewIceCream(GameObject prefab)
    {
        // Remove current one if it exists
        if (currentIceCream != null)
        {
            Destroy(currentIceCream);
        }

        // Spawn and attach new one
        currentIceCream = Instantiate(prefab, scoopAttachPoint);
        currentIceCream.transform.localPosition = Vector3.zero;
        currentIceCream.transform.localRotation = Quaternion.identity;
    }
}
