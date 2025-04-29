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
    public float chaseSpeed = 3.5f;
    public static bool playBreathing = false;
    public Transform spawnPoint;

    public AudioSource giggle;

    void Start()
    {
        playerTransform = player.transform;
        nav = GetComponent<NavMeshAgent>();
        nav.speed = chaseSpeed;

        animator = sprite.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {   
        bool isMoving = nav.desiredVelocity.magnitude > 0.1f;
        if (TriggerChase.trigChase && (LoadOrder.index == 4 || LoadOrder.index == 8))
        {

            if (PlayerHide.isHiding)
            {
                playBreathing = true;
                nav.destination = spawnPoint.position;
            }
            else
            {
                if (LoadOrder.index == 7)
                {
                    nav.speed = 5f; 
                }
                playBreathing = false;
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
                    giggle.Play();
                    playBreathing = true;
                }
                else 
                {
                    giggle.Stop();
                    playBreathing = false;
                }
            }
        }
        else
        {
            playBreathing = false;
            nav.destination = spawnPoint.position;
            if (!isMoving)
            {
                animator.SetBool("isMoving", false);
            }
        }
    }
}
