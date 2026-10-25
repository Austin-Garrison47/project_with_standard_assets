
using UnityEngine;

public class ShootingTarget : MonoBehaviour
{
    public void Hit()
    {
        Destroy(gameObject);
    }
}
