using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServeOrder : MonoBehaviour
{
    public void OnTriggerEnter(Collider collide)
    {
        if (Cone.currentOrderInt == LoadOrder.targetOrderInt)
        {
            LoadOrder.orderFinished = true;
            if (LoadOrder.index == 1) // 2nd order
            {
                GeneratorManager.genFailed = true;
            }
            else if (LoadOrder.index == 3) // 4th order
            {
                GeneratorManager.genFailed = true;
            }
            else if (LoadOrder.index == 7) // 8th order
            {
                GeneratorManager.genFailed = true;
            }
            LoadOrder.index++;
            Debug.Log("ORDER FINISHED AND CORRECT");
        }
        if (collide.CompareTag("Cone"))
        {
            Destroy(collide.transform.root.gameObject);
        }
        if (collide.CompareTag("Blue") || collide.CompareTag("Choc") ||  collide.CompareTag("Strawberry"))
        {
            Destroy(collide.gameObject);
        }
        Debug.Log("CURRENT ORDER INT: ");
        Debug.Log(Cone.currentOrderInt);

        Cone.currentOrderInt = 0;
    }
            
}
