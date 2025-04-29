using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMovementandOrder : MonoBehaviour
{

    public GameObject spawn;
    private Transform spawnPoint;
    public GameObject serveLocation;
    private Transform locationTransform;
    public UnityEngine.AI.NavMeshAgent nav;

    public GameObject customer1;
    public GameObject customer2;
    private bool isLeaving = false;

    void Start()
    {
        locationTransform = serveLocation.transform;
        spawnPoint = spawn.transform;
        nav = GetComponent<UnityEngine.AI.NavMeshAgent>();

        customer1.SetActive(true);
        customer2.SetActive(false);
    }

    void Update()
    {
        if (!LoadOrder.orderFinished && !isLeaving)
        {
            nav.destination = locationTransform.position;
            isLeaving = true;

        }
        else if (LoadOrder.orderFinished)
        {
            nav.destination = spawnPoint.position;
            StartCoroutine(SwitchCustomers());
            isLeaving = false;
        }
    }

    IEnumerator SwitchCustomers()
    {
        yield return new WaitForSeconds(10f);

        // Switch customers
        customer1.SetActive(false);
        customer2.SetActive(true);

        // Reset NPC position
        transform.position = spawnPoint.position;
        isLeaving = false;
    }
}