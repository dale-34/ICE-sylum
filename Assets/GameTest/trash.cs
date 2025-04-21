using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trash : MonoBehaviour
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
        
        {
            GameObject[] orders = GameObject.FindGameObjectsWithTag("IceCream");
            foreach (GameObject IceCream in orders)
                GameObject.Destroy(IceCream);

            gameFlow.coneValue = 0;
        }
    }
}
