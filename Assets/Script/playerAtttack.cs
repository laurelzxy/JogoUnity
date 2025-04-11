using UnityEngine;

public class playerAttack : MonoBehaviour
{
    public float attackRange = 6f;
    public int damage = 10;
    public LayerMask enemyLayer;

    private Animator animator;

    // === VIDA DO PLAYER ===
    public int maxHealth = 50;
    private int currentHealth;
    private bool isDead = false;

    void Start()
    {
        animator = GetComponent<Animator>();
        currentHealth = maxHealth;

     
    }

    void Update()
    {
        animator = GetComponent<Animator>();

        if (Input.GetButtonDown("Fire1")) // Ou Input.GetKeyDown(KeyCode.Mouse0)
        {
            Attack();
            animator.SetTrigger("Attack");

        }
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

    void Attack()
    {


        // Raio para frente do player
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, attackRange, enemyLayer))
        {
            Debug.Log("Acertou: " + hit.collider.name);

            EnemyHealth enemy = hit.collider.GetComponent<EnemyHealth>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }


                //if (animator != null)
                {
                   // animator.SetTrigger("Hit");
                }
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
