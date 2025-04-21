using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServeOrder : MonoBehaviour
{
    public void OnTriggerEnter(Collider collide)
    {
        if (Cone.currentOrderInt == LoadOrder.targetOrderInt)
        {
            LoadOrder.index++;
            LoadOrder.orderFinished = true;
            Debug.Log("Correct order!");
        }
        else if (Cone.currentOrderInt != LoadOrder.targetOrderInt)
        {
            Debug.Log("Wrong Order");
        }
    }
            
}
