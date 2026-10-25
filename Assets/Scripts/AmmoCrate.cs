
using UnityEngine;

public class AmmoCrate : MonoBehaviour
{
    public ManageWeapons weapons;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            weapons.RefillAmmo();
            Destroy(gameObject);
        }
    }
}
