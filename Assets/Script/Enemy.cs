using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public Transform player;
    public float detectionRange = 10f;
    public float attackRange = 6f;
    public float timeBetweenAttacks = 1.5f;
    public int damage = 10;

    private NavMeshAgent agent;
    private Animator animator;
    private bool alreadyAttacked;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.position);

        if (distance <= attackRange)
        {
            agent.isStopped = true;
            animator.SetBool("isWalking", false);


        }
        else if (distance <= detectionRange)
        {
            agent.isStopped = false;
            agent.SetDestination(player.position);
            animator.SetBool("isWalking", true);
        }
        else
        {
            agent.isStopped = true;
            animator.SetBool("isWalking", false);
        }
    }
}

    