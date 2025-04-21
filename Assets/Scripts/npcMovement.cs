using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class npcMovement : MonoBehaviour
{
    private GameObject spawn;
    private Transform spawnPoint;
    public GameObject newOrder;
    public GameObject location;
    private Transform playerTransform;
    private UnityEngine.AI.NavMeshAgent nav;

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = location.transform;
        spawnPoint = GameObject.FindGameObjectWithTag("Respawn").transform;
        nav = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        nav.destination = playerTransform.position;
    }

    void OnTriggerEnter(Collider myCollider)
    {
        if (myCollider.gameObject.tag == "Player")
        {
            ChangeTarget(spawnPoint.position);
            Instantiate(newOrder, spawnPoint.position, Quaternion.identity);
            StartCoroutine(Destroy());
        }
        
    }

    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(10f);
        Destroy(gameObject);
    }

    public void ChangeTarget(Vector3 backToSpawn)
    {
        if (nav.hasPath)
        {
            nav.ResetPath();
        }

        nav.SetDestination(backToSpawn);
    }

}
