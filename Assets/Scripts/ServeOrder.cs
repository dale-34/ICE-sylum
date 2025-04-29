using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ServeOrder : MonoBehaviour
{
    public TMP_Text wrongOrder;

    void Start()
    {
        wrongOrder.text = "";
    }

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
        if (collide.CompareTag("Blue") || collide.CompareTag("Choc") || collide.CompareTag("Strawberry"))
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
