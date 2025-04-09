using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public float detectionRange = 10f;
    public float attackRange = 2f;
    public Transform player;
    private NavMeshAgent agent;
    private Animator animator;

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
            animator.SetTrigger("Attack");
            // Aqui você pode adicionar dano ao player se quiser
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
