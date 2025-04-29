using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerChase : MonoBehaviour
{
    public static bool trigChase = false;
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player") && GeneratorManager.genFailed)
        {
            trigChase = true;
            Debug.Log("Chase Triggered");
        }
    }
}
