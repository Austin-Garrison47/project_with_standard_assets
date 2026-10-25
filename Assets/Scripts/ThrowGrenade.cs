
using UnityEngine;

public class ThrowGrenade : MonoBehaviour
{
    public GameObject grenade;
    public Transform playerCamera;
    public float throwForce = 500f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            Throw();
        }
    }

    void Throw()
    {
        GameObject newGrenade = Instantiate(
            grenade,
            playerCamera.position + playerCamera.forward,
            playerCamera.rotation
        );

        Rigidbody rb = newGrenade.GetComponent<Rigidbody>();
        rb.AddForce(playerCamera.forward * throwForce);

        Destroy(newGrenade, 10f);
    }
}
