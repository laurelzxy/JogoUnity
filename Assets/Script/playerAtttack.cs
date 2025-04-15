using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class playerAttack : MonoBehaviour
{
    public float attackRange = 6f;
    public int damage = 10;
    public LayerMask enemyLayer;

    private Animator animator;
    private bool isAttacking = false;

    private HealthBarScrollbar scroolBar;

    public bool estaInvencivel = false;

    [Header("Vida do jogador")]
    public float currentHealth;
    public float maxHealth = 100;

    [Header("Invencibilidade")]
    public GameObject escudoVisual;
    private ShieldCollision shield;

    private bool isDead = false;

    void Start()
    {
        animator = GetComponent<Animator>();
        scroolBar = GetComponent<HealthBarScrollbar>();
        currentHealth = maxHealth;

        currentHealth = maxHealth;

        shield = GetComponentInChildren<ShieldCollision>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && !isAttacking)
        {
            Attack();
            animator.SetTrigger("Attack");
            isAttacking = true;
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            TakeDamage(50);
            Debug.Log("dano");
        }

        if (currentHealth <= 0)
        {
            isDead = true;
            Debug.Log("MORREU");
        }


        if (isDead)
        {
           // SceneManager.LoadScene("DeathScene");

            Debug.Log("MORREU");
        }
    }

    public void TakeDamage(int amount)
    {
        if (isDead || (shield != null && shield.IsShieldActive)) return;

        currentHealth -= amount;
        scroolBar.UpdatePlayerHealthBar(Mathf.RoundToInt(currentHealth));

        Debug.Log("Player levou dano! Vida atual: " + currentHealth);

        if (animator != null)
        {
            animator.SetTrigger("Hit");
        }

        //if (currentHealth <= 0)
        //{
        //    Die();
        //}
    }

    // === MÉTODO PARA ATACAR ===
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

        // Delay entre os ataques (opcional, caso você queira uma pausa entre os ataques)
        StartCoroutine(ResetAttackCooldown());
    }

    // Função para reiniciar o ataque (cooldown)
    IEnumerator ResetAttackCooldown()
    {
        yield return new WaitForSeconds(0.5f);  // Ajuste o tempo de cooldown entre os ataques
        isAttacking = false;  // Permite um novo ataque após o cooldown
    }

    // === MÉTODO DE MORTE ===
    void Die()
    {
       // isDead = true;
        //Debug.Log("Player morreu!");
       // animator.SetTrigger("Death");

        // Aqui você pode desativar controles, mostrar tela de Game Over, etc
    }
}
