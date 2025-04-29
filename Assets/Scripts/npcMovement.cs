using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npcMovement : MonoBehaviour
{
    public GameObject spawn;
    private Transform spawnPoint;
    public GameObject newOrder;
    public GameObject location;
    private Transform playerTransform;
    private UnityEngine.AI.NavMeshAgent nav;

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = location.transform;
        spawnPoint = spawn.transform;
        nav = GetComponent<UnityEngine.AI.NavMeshAgent>();
        StartCoroutine(Destroy());
    }

    // Update is called once per frame
    void Update()
    {
        nav.destination = playerTransform.position;
    }

    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(30f);
        Instantiate(newOrder, spawnPoint.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
