using UnityEngine;

public class playerAttack : MonoBehaviour
{
    public float attackRange = 5f;
    public int damage = 10;
    public LayerMask enemyLayer;

    private Animator animator;

    // === VIDA DO PLAYER ===
    public int maxHealth = 100;
    private int currentHealth;
    private bool isDead = false;

    void Start()
    {
        animator = GetComponent<Animator>();
        currentHealth = maxHealth;
    }

    void Update()
    {
        
    }

   

    // === MÉTODO PARA RECEBER DANO ===
    public void TakeDamage(int amount)
    {
        if (isDead) return;

        currentHealth -= amount;
        Debug.Log("Player levou dano! Vida atual: " + currentHealth);

        if (animator != null)
        {
            animator.SetTrigger("Hit");
        }

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        isDead = true;
        Debug.Log("Player morreu!");
        animator.SetTrigger("Death");

        // Aqui você pode desativar controles, mostrar tela de Game Over, etc
    }
}
