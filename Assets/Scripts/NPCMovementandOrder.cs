using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMovementandOrder : MonoBehaviour
{

    public GameObject spawn;
    private Transform spawnPoint;
    public GameObject newOrder;
    public GameObject serveLocation;
    private Transform locationTransform;
    private UnityEngine.AI.NavMeshAgent nav;

    // Start is called before the first frame update
    void Start()
    {
        locationTransform = serveLocation.transform;
        spawnPoint = spawn.transform;
        nav = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (LoadOrder.orderFinished = true)
        {

            nav.destination = locationTransform.position;

        }
        else if (LoadOrder.orderFinished = false)
        {

            nav.destination = spawnPoint.position;
            StartCoroutine(Destroy());

        }
    }

    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(10f);
        Instantiate(newOrder, spawnPoint.position, Quaternion.identity);
        Destroy(gameObject);
    }
}