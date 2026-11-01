
using UnityEngine;

public class HealthPack : MonoBehaviour
{
    public int healthAmount = 50;

    void OnTriggerEnter(Collider other)
    {
        ManagePlayerHealth playerHealth =
            other.GetComponentInParent<ManagePlayerHealth>();

        if (playerHealth != null)
        {
            playerHealth.increaseHealth(healthAmount);
            Destroy(gameObject);
        }
    }
}
