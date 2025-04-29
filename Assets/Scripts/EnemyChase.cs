using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyChase : MonoBehaviour
{
    //Animator animator;
    //bool isMoving = GetComponent<NavMeshAgent>().desiredVelocity.magnitude > 0.1f;

    public GameObject sprite;
    Animator animator;
    public GameObject player;
    private Transform playerTransform;
    private NavMeshAgent nav;



    // Start is called before the first frame update
    void Start()
    {
        playerTransform = player.transform;
        nav = GetComponent<NavMeshAgent>();
        animator = sprite.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (LoadOrder.index == 1 && TriggerChase.trigChase)
        {
            bool isMoving = nav.desiredVelocity.magnitude > 0.1f;

            nav.destination = playerTransform.position;

            
            if (isMoving)
            {
                animator.SetBool("isMoving", true);
            }

            if (!isMoving)
            {
                animator.SetBool("isMoving", false);
            }
        }
    }
}
