using UnityEngine;
using System.Collections;

public class MagicCrystal : MonoBehaviour
{
    public AudioClip pickupSound; // opcional
    public ParticleSystem pickupEffect; // opcional

    // Upgrade de velocidade
    public float bonusDeVelocidade = 10f;
    public float duracaoDoBonus = 5f;

    void Update()
    {
        transform.Rotate(0, 50 * Time.deltaTime, 0); // faz o cristal girar
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Aumenta a velocidade do player
            movimentoJogador player = other.GetComponent<movimentoJogador>();
            if (player != null)
            {
                StartCoroutine(AplicarBonusDeVelocidade(player));

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

    IEnumerator AplicarBonusDeVelocidade(movimentoJogador player)
    {
        player.velocidadeAtual += bonusDeVelocidade;
        Debug.Log(" Velocidade aumentada!");

        yield return new WaitForSeconds(duracaoDoBonus);

        player.velocidadeAtual = player.velocidadeBase;
        Debug.Log(" Velocidade restaurada.");
    }
}

