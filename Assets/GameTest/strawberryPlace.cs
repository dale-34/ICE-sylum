using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class strawberryPlace : MonoBehaviour
{
    public Transform cloneObj;
    private int flavorInt;
    //choc = 1, vanil = 2, strawb = 3
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseDown()
    {
     
        if (gameObject.name == "strawberryScoop" && gameFlow.coneValue == 0)
        {
            Instantiate(cloneObj, new Vector3(0, 1.0f, 0), cloneObj.rotation);
            gameFlow.coneValue += 3;
        }
        else if (gameFlow.coneValue > 0 && gameFlow.coneValue < 10)
        {
            Instantiate(cloneObj, new Vector3(0, 2.0f, 0), cloneObj.rotation);
            gameFlow.coneValue += 30;
        }
        else if (gameFlow.coneValue > 10 && gameFlow.coneValue < 100)
        {
            Instantiate(cloneObj, new Vector3(0, 3.0f, 0), cloneObj.rotation);
            gameFlow.coneValue += 300;
        }

        //gameFlow.coneValue += flavorInt;
        Debug.Log("cone = " + gameFlow.coneValue);

    }
}
