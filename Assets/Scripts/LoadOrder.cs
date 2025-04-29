using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadOrder : MonoBehaviour
{
    public GameObject[] Orders;
    public int[] orderValues;

    public Transform spawnPoint;
    public GameObject servePoint;

    public static bool orderFinished = false;
    public static int targetOrderInt = 0;
    public static int index = 0;

    private GameObject currOrder;
    public void Start()
    {
        NewOrder();
    }
    
    public void Update()
    {
        if (orderFinished)
        {
            Destroy(currOrder);
            NewOrder();
        }
    }

    private void NewOrder()
    {
        orderFinished = false;
        if (index <= orderValues.Length)
        {
            currOrder = Instantiate(Orders[index], spawnPoint.position, spawnPoint.rotation);
            targetOrderInt = orderValues[index]; 
            Debug.Log("Spawning");
        }
    }
}
