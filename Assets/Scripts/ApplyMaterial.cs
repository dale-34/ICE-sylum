using UnityEngine;

public class ApplyMaterial : MonoBehaviour
{
    public Material newMaterial;

    void Start()
    {
        MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
        if (meshRenderer != null)
        {
            meshRenderer.material = newMaterial;
        }
    }
}
