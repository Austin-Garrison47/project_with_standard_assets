
using UnityEngine;
using TMPro;

public class ConnectGeneratedPlayer : MonoBehaviour
{
    public ManageWeapons manageWeapons;
    public ThrowGrenade throwGrenade;

    public TMP_Text healthText;
    public TMP_Text livesText;

    private bool playerConnected = false;

    void Update()
    {
        if (playerConnected)
            return;

        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player == null)
            return;

        Camera playerCamera = player.GetComponentInChildren<Camera>();

        if (playerCamera == null)
            return;

        if (manageWeapons != null)
            manageWeapons.playerCamera = playerCamera;

        if (throwGrenade != null)
            throwGrenade.playerCamera = playerCamera.transform;

        ManagePlayerHealth playerHealth =
            player.GetComponent<ManagePlayerHealth>();

        if (playerHealth != null)
        {
            playerHealth.healthInfo = healthText;
            playerHealth.livesInfo = livesText;
        }

        playerConnected = true;
    }
}
