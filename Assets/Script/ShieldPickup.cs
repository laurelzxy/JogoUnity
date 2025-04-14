using UnityEngine;

public class ShieldPickup : MonoBehaviour
{
    [Header("Som/efeito visual opcional")]
    [SerializeField] GameObject pickupEffect;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        // Tenta buscar o escudo no próprio player OU nos filhos
        ShieldCollision shield = other.GetComponent<ShieldCollision>();
        if (shield == null)
        {
            shield = other.GetComponentInChildren<ShieldCollision>();
        }

        Debug.Log("Tentando ativar escudo no objeto: " + other.name);

        if (shield != null)
        {
            shield.ActivateShield();
            Debug.Log("Escudo ativado!");

            if (pickupEffect != null)
                Instantiate(pickupEffect, transform.position, Quaternion.identity);

            Destroy(gameObject);
        }
        else
        {
            Debug.LogWarning("ShieldCollision não encontrado no Player!");
        }
    }
}
