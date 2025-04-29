using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class serveCone : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
    {
        Destroy(gameObject);

        /*
        if (gameFlow.orderValue == gameFlow.coneValue)
        {
            Debug.Log("Correct! Great job");

            GameObject[] orders = GameObject.FindGameObjectsWithTag("IceCream");
            foreach (GameObject IceCream in orders)
                GameObject.Destroy(IceCream);

            gameFlow.coneValue = 0;
        } else if (gameFlow.orderValue != gameFlow.coneValue)
        {
            Debug.Log("That's wrong try again");

            GameObject[] orders = GameObject.FindGameObjectsWithTag("IceCream");
            foreach (GameObject IceCream in orders)
                GameObject.Destroy(IceCream);

            gameFlow.coneValue = 0;
        }
        */
    }
}
