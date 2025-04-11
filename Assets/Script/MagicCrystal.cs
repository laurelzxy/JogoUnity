using UnityEngine;

public class MagicCrystal : MonoBehaviour
{
    public AudioClip pickupSound; // opcional
    public ParticleSystem pickupEffect; // opcional


    void Update()
    {
        transform.Rotate(0, 50 * Time.deltaTime, 0);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Avisa o GameManager que coletou um cristal
            // GameManager.instance.CollectCrystal();

            // Toca som (se tiver)
            if (pickupSound != null)
                AudioSource.PlayClipAtPoint(pickupSound, transform.position);

            // Efeito mágico
            if (pickupEffect != null)
                Instantiate(pickupEffect, transform.position, Quaternion.identity);

            // Destrói o cristal
            Destroy(gameObject);
        }
    }
}
