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

    public HealthBar healthBar;
    public float damageRate = 5f; 
    public float attackRange = 2f;


    void Start()
    {
        playerTransform = player.transform;
        nav = GetComponent<NavMeshAgent>();
        animator = sprite.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {   
        // LoadOrder.index == 1 &&
        if ( TriggerChase.trigChase)
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
             // Check distance to player
            float distance = Vector3.Distance(transform.position, playerTransform.position);
            if (distance < attackRange)
            {
                healthBar.curr = Mathf.Min(healthBar.curr + damageRate * Time.deltaTime, healthBar.full);
            }
        }
    }
}
