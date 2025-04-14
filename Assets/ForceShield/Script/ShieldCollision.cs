using System.Collections;
using UnityEngine;

public class ShieldCollision : MonoBehaviour
{
    [Header("Tags que ativam o efeito de colisão")]
    [SerializeField] string[] _collisionTag;

    [Header("Tempo de escudo ativo (segundos)")]
    [SerializeField] float shieldDuration = 5f;

    [Header("Referência visual do escudo")]
    [SerializeField] GameObject shieldVisual;

    float hitTime;
    Material mat;
    bool shieldActive = false;

    public bool IsShieldActive => shieldActive;




    void Start()
    {
        if (shieldVisual != null)
            shieldVisual.SetActive(false);

        if (shieldVisual != null && shieldVisual.GetComponent<Renderer>() != null)
        {
            mat = shieldVisual.GetComponent<Renderer>().material;
        }
    }

    void Update()
    {
        if (!shieldActive || mat == null) return;

        if (hitTime > 0)
        {
            float myTime = Time.deltaTime * 1000;
            hitTime -= myTime;
            if (hitTime < 0) hitTime = 0;
            mat.SetFloat("_HitTime", hitTime);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (!shieldActive) return;

        foreach (string tag in _collisionTag)
        {
            if (collision.transform.CompareTag(tag))
            {
                ContactPoint[] _contacts = collision.contacts;
                foreach (var contact in _contacts)
                {
                    if (mat != null)
                    {
                        mat.SetVector("_HitPosition", transform.InverseTransformPoint(contact.point));
                        hitTime = 500;
                        mat.SetFloat("_HitTime", hitTime);
                    }
                }
                Debug.Log("Dano bloqueado por escudo de colisão.");
            }
        }
    }

    public void ActivateShield()
    {
        if (shieldActive) return;

        shieldActive = true;
        Debug.Log("Escudo místico ativado!");

        if (shieldVisual != null)
            shieldVisual.SetActive(true);

        StartCoroutine(ShieldTimer());
    }

    IEnumerator ShieldTimer()
    {
        yield return new WaitForSeconds(shieldDuration);

        shieldActive = false;
        if (shieldVisual != null)
            shieldVisual.SetActive(false);

        Debug.Log("Escudo místico desativado.");
    }

 

}



