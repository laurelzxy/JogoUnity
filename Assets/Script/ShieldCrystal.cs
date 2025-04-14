using UnityEngine;
using System.Collections;

public class ShieldCrystal : MonoBehaviour
{
    public float duracaoEscudo = 5f;
    public AudioClip pickupSound;
    public ParticleSystem pickupEffect;

    void Update()
    {
        transform.Rotate(0, 50 * Time.deltaTime, 0);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerAttack player = other.GetComponent<playerAttack>();
            if (player != null)
            {
                StartCoroutine(AtivarEscudo(player));
            }

            if (pickupSound != null)
                AudioSource.PlayClipAtPoint(pickupSound, transform.position);

            if (pickupEffect != null)
                Instantiate(pickupEffect, transform.position, Quaternion.identity);

            Destroy(gameObject);
        }
    }

    IEnumerator AtivarEscudo(playerAttack player)
    {
        player.estaInvencivel = true;

        if (player.escudoVisual != null)
            player.escudoVisual.SetActive(true);

        yield return new WaitForSeconds(duracaoEscudo);

        player.estaInvencivel = false;

        if (player.escudoVisual != null)
            player.escudoVisual.SetActive(false);
    }

}
