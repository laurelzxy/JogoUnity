using UnityEngine;

public class MagicCrystal : MonoBehaviour
{
    public AudioClip pickupSound; // Som opcional ao pegar o cristal
    public ParticleSystem pickupEffect; // Efeito opcional ao pegar o cristal

    // Upgrade de velocidade permanente
    public float bonusDeVelocidade = 10f;

    void Update()
    {
        transform.Rotate(0, 50 * Time.deltaTime, 0); // Faz o cristal girar
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Aumenta a velocidade do player
            movimentoJogador player = other.GetComponent<movimentoJogador>();
            if (player != null)
            {
                // Aplica bônus permanente
                player.velocidadeAtual += bonusDeVelocidade;

                // Ativa o efeito visual de buff, se existir
                if (player.efeitoBuff != null)
                    player.efeitoBuff.SetActive(true);

                // Ativa a animação (se tiver)
                Animator anim = player.GetComponent<Animator>();
                if (anim != null)
                {
                    anim.SetTrigger("Velocidade");
                }
            }

            // Toca som (se tiver)
            if (pickupSound != null)
                AudioSource.PlayClipAtPoint(pickupSound, transform.position);

            // Efeito mágico (se tiver)
            if (pickupEffect != null)
                Instantiate(pickupEffect, transform.position, Quaternion.identity);

            // Destrói o cristal
            Destroy(gameObject);
        }
    }
}
