using UnityEngine;
using System.Collections;

public class FireDamage : MonoBehaviour
{
    private bool playerInside = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerAttack playerHealth = other.GetComponent<playerAttack>();

            if (playerHealth != null)
            {
                // Dano inicial
                playerHealth.TakeDamage(10);
                Debug.Log(" Dano inicial do fogo!");
                playerInside = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && playerInside)
        {
            playerAttack playerHealth = other.GetComponent<playerAttack>();

            if (playerHealth != null)
            {
                // Inicia o dano cont�nuo ap�s sair do fogo
                StartCoroutine(DanoCont�nuo(playerHealth));
                Debug.Log(" Iniciando dano cont�nuo ap�s sair do fogo...");
                playerInside = false;
            }
        }
    }

    IEnumerator DanoCont�nuo(playerAttack playerHealth)
    {
        int ciclos = 3;

        for (int i = 0; i < ciclos; i++)
        {
            yield return new WaitForSeconds(0.5f);
            playerHealth.TakeDamage(5);
            Debug.Log(" Dano cont�nuo de fogo (" + (i + 1) + "/3)");
        }
    }
}