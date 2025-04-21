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

    public void Start()
    {
        NewOrder();
    }
    
    public void Update()
    {
        if (orderFinished)
        {
            NewOrder();
        }
    }

    private void NewOrder()
    {
        orderFinished = false;
        if (index <= orderValues.Length)
        {
            Instantiate(Orders[index], spawnPoint.position, spawnPoint.rotation);
            targetOrderInt = orderValues[index]; 
            Debug.Log("Spawning");
        }
    }
}
