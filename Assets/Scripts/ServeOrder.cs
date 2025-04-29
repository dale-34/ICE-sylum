using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ServeOrder : MonoBehaviour
{
    public void OnTriggerEnter(Collider collide)
    {
        if (Cone.currentOrderInt == LoadOrder.targetOrderInt)
        {
            LoadOrder.orderFinished = true;

            if (LoadOrder.index == 1 || LoadOrder.index == 3 || LoadOrder.index == 7)
            {
                GeneratorManager.genFailed = true;
            }
            
            else if (LoadOrder.index == 8)
            {
                SceneManager.LoadScene("EndScreen");
            }
            LoadOrder.index++;
            Debug.Log("ORDER FINISHED AND CORRECT");
        }

        if (collide.CompareTag("Cone"))
        {
            Destroy(collide.transform.root.gameObject);
        }
        if (collide.CompareTag("Blue") || collide.CompareTag("Choc") || collide.CompareTag("Strawberry"))
        {
            Destroy(collide.gameObject);
        }

        Cone.currentOrderInt = 0;
    }
}
