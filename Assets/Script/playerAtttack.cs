using System.Collections;
using UnityEngine;

public class playerAttack : MonoBehaviour
{
    public float attackRange = 6f;  // Dist�ncia do ataque
    public int damage = 10;         // Dano do ataque
    public LayerMask enemyLayer;    // Camada de inimigos

    private Animator animator;
    private bool isAttacking = false;  // Verifica se o jogador est� atacando

    public bool estaInvencivel = false;

    // === Invencibilidade ===
    [Header("Invencibilidade")]
    public GameObject escudoVisual;   // Objeto com part�cula ou efeito visual do escudo
    private ShieldCollision shield;   // Refer�ncia ao escudo

    // === VIDA DO PLAYER ===
    public int maxHealth = 50;
    private int currentHealth;
    private bool isDead = false;

    // Refer�ncia ao script da UI (barra de vida)
    public PlayerHealthUI playerHealthUI;

    void Start()
    {
        animator = GetComponent<Animator>();
        currentHealth = maxHealth;

        // Pega refer�ncia para o escudo (pode estar em um filho)
        shield = GetComponentInChildren<ShieldCollision>();
    }

    void Update()
    {
        // Verifica se o jogador apertou o bot�o de ataque
        if (Input.GetButtonDown("Fire1") && !isAttacking) // Ou Input.GetKeyDown(KeyCode.Mouse0)
        {
            Attack();
            animator.SetTrigger("Attack");
            isAttacking = true;  // Marca que o jogador est� atacando
        }
    }

    // === M�TODO PARA RECEBER DANO ===
    public void TakeDamage(int amount)
    {
        // Verifica se o jogador est� invenc�vel ou morto
        if (isDead || (shield != null && shield.IsShieldActive)) return;

        currentHealth -= amount;
        Debug.Log("Player levou dano! Vida atual: " + currentHealth);

        if (animator != null)
        {
            animator.SetTrigger("Hit");
        }

        // Atualiza a barra de vida do jogador
        if (playerHealthUI != null)
        {
            playerHealthUI.TakeDamage(amount);  // Chama o m�todo da barra de vida para atualizar
        }

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    // === M�TODO PARA ATACAR ===
    void Attack()
    {
        // Raio para frente do player
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, attackRange, enemyLayer))
        {
            Debug.Log("Acertou: " + hit.collider.name);

            // Verifica se o inimigo foi atingido
            EnemyHealth enemy = hit.collider.GetComponent<EnemyHealth>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);  // Aplica o dano no inimigo
            }
        }

        // Delay entre os ataques (opcional, caso voc� queira uma pausa entre os ataques)
        StartCoroutine(ResetAttackCooldown());
    }

    // Fun��o para reiniciar o ataque (cooldown)
    IEnumerator ResetAttackCooldown()
    {
        yield return new WaitForSeconds(0.5f);  // Ajuste o tempo de cooldown entre os ataques
        isAttacking = false;  // Permite um novo ataque ap�s o cooldown
    }

    // === M�TODO DE MORTE ===
    void Die()
    {
        isDead = true;
        Debug.Log("Player morreu!");
        animator.SetTrigger("Death");

        // Aqui voc� pode desativar controles, mostrar tela de Game Over, etc
    }
}
