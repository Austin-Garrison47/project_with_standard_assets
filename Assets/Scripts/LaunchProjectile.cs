
using UnityEngine;

public class LaunchProjectile : MonoBehaviour
{
    public GameObject projectile;
    public Transform player;
    public float projectileForce = 500f;
    public float launchInterval = 5f;

    void Start()
    {
        InvokeRepeating("Launch", 2f, launchInterval);
    }

    void Launch()
    {
        if (player != null)
        {
            transform.LookAt(player);
        }

        GameObject newProjectile = Instantiate(
            projectile,
            transform.position + Vector3.up,
            transform.rotation
        );

        Rigidbody rb = newProjectile.GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * projectileForce);

        Destroy(newProjectile, 5f);
    }
}
