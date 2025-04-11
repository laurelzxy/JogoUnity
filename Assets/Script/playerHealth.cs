using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float attackRange = 6f;
    public int damage = 10;
    public LayerMask enemyLayer;

    private Animator animator;



    void Update()
    {

        animator = GetComponent<Animator>();

        if (Input.GetButtonDown("Fire1")) // Ou Input.GetKeyDown(KeyCode.Mouse0)
        {
            Attack();
            animator.SetTrigger("Attack");

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


            if (animator != null)
            {
                animator.SetTrigger("Hit");
            }
        }


    }
}
