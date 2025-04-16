using UnityEngine;

public class PlayerAbilities : MonoBehaviour
{
    public bool hasFireAbility = false;
    public ParticleSystem fireVFX;
    public float range = 10f;
    public LayerMask iceLayer;

    void Update()
    {
        if (hasFireAbility && Input.GetKeyDown(KeyCode.F))
        {
            if (fireVFX != null) fireVFX.Play();

            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, range, iceLayer))
            {
                IceBlock ice = hit.collider.GetComponent<IceBlock>();
                if (ice != null)
                {
                    ice.Melt(); // função que você vai criar no gelo
                }
            }
        }
    }
}

