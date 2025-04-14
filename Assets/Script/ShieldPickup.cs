using UnityEngine;

public class ShieldPickup : MonoBehaviour
{
    [Header("Som/efeito visual opcional")]
    public AudioClip pickupSound;

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

            // Toca som (se tiver)
            if (pickupSound != null)
                AudioSource.PlayClipAtPoint(pickupSound, transform.position);

            Destroy(gameObject);
        }
        else
        {
            Debug.LogWarning("ShieldCollision não encontrado no Player!");
        }
    }
}
