using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ServeOrder : MonoBehaviour
{   
    public Text wrongOrder;

    void Start()
    {
        wrongOrder.text = "";
    }
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
            else if (LoadOrder.index == 8)
            {
                SceneManager.LoadScene("EndScene");
            }
            LoadOrder.index++;
            Debug.Log("ORDER FINISHED AND CORRECT");
        } 
        else if (collide.CompareTag("Cone") && Cone.currentOrderInt != LoadOrder.targetOrderInt)
        {
            StartCoroutine(ShowWrongOrderText()); 
        }
        if (collide.CompareTag("Cone"))
        {
            Destroy(collide.transform.root.gameObject);
        }
        if (collide.CompareTag("Blue") || collide.CompareTag("Choc") ||  collide.CompareTag("Strawberry"))
        {
            Destroy(collide.gameObject);
        }
        Cone.currentOrderInt = 0;
    }
    
    private IEnumerator ShowWrongOrderText()
    {
        wrongOrder.text = "WRONG ORDER";
        yield return new WaitForSeconds(3f); 
        wrongOrder.text = "";
    }
}
