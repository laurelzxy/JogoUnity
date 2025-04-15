using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 30;
    private int currentHealth;
    private Animator animator;
    private bool isDead = false;


    public int damageAmount = 10; // quanto de dano ele causa
    public float attackCooldown = 1f; // tempo entre ataques
    private float lastAttackTime;

    void Start()
    {
        currentHealth = maxHealth;
        animator = GetComponent<Animator>(); //  pegando Animator
    }


    public void TakeDamage(int amount)
    {
        if (isDead) return;

        currentHealth -= amount;
        Debug.Log("Inimigo levou dano! Vida atual: " + currentHealth);

        if (animator != null)
        {
            animator.SetTrigger("Hit");
        }

        if (currentHealth <= 0)
        {
            Die();
            Debug.Log("inimigo morreu");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && Time.time > lastAttackTime + attackCooldown)
        {
            Debug.Log("Inimigo atacou o player!");

            playerAttack playerHealth = other.GetComponent<playerAttack>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damageAmount);
                lastAttackTime = Time.time;
                animator.SetTrigger("attack");
            }
        }
    }


    void Die()
    {
        isDead = true;
        Debug.Log("Inimigo morreu!");
        animator.SetTrigger("Death"); //  se tiver animação de morte
        Destroy(gameObject, 2f); 
    }
}
