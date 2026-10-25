
using UnityEngine;

public class GrenadeExplosion : MonoBehaviour
{
    public GameObject explosion;

    void OnCollisionEnter(Collision collision)
    {
        if (explosion != null)
        {
            GameObject effect = Instantiate(
                explosion,
                transform.position,
                Quaternion.identity
            );

            Destroy(effect, 3f);
        }

        Destroy(gameObject);
    }
}
