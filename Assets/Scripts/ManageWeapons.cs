
using UnityEngine;
using TMPro;
using System.Collections;

public class ManageWeapons : MonoBehaviour
{
    public Camera playerCamera;
    public TMP_Text ammoText;
    public TMP_Text targetScoreText;
    public TMP_Text maxAmmoText;

    public int gunAmmo = 10;
    public int maxAmmo = 10;
    public int targetScore = 0;
    public float shootingRange = 100f;
    public float reloadTime = 2f;

    private bool isReloading = false;
    private int originalMaxAmmo;
    private float originalReloadTime;

    void Start()
    {
        originalMaxAmmo = maxAmmo;
        originalReloadTime = reloadTime;

        UpdateAmmo();

        if (targetScoreText != null)
            targetScoreText.text = "Score: " + targetScore;
    }

    void Update()
    {
        if (Time.timeScale == 0f)
            return;

        if (Input.GetMouseButtonDown(0) && gunAmmo > 0 && !isReloading)
        {
            Shoot();
        }

        if (Input.GetKeyDown(KeyCode.R) && !isReloading)
        {
            StartCoroutine(Reload());
        }
    }

    void Shoot()
    {
        if (playerCamera == null)
            return;

        gunAmmo--;
        UpdateAmmo();

        RaycastHit hit;

        if (Physics.Raycast(playerCamera.transform.position,
            playerCamera.transform.forward, out hit, shootingRange))
        {
            Debug.Log("Hit: " + hit.collider.name);

            ShootingTarget target =
                hit.collider.GetComponent<ShootingTarget>();

            if (target != null)
            {
                target.Hit();
                targetScore++;

                if (targetScoreText != null)
                    targetScoreText.text = "Score: " + targetScore;
            }
        }
    }

    IEnumerator Reload()
    {
        isReloading = true;
        ammoText.text = "Reloading...";

        yield return new WaitForSeconds(reloadTime);

        gunAmmo = maxAmmo;
        isReloading = false;
        UpdateAmmo();
    }

    public void RefillAmmo()
    {
        if (!isReloading)
        {
            gunAmmo = maxAmmo;
            UpdateAmmo();
        }
    }

    public void ChangeMaxAmmo(int index)
    {
        if (index == 0)
            maxAmmo = originalMaxAmmo * 2;
        else if (index == 1)
            maxAmmo = originalMaxAmmo * 5;
        else if (index == 2)
            maxAmmo = originalMaxAmmo * 10;

        gunAmmo = maxAmmo;
        UpdateAmmo();
    }

    public void ChangeReloadTime(int index)
    {
        if (index == 0)
            reloadTime = originalReloadTime * 0.5f;
        else if (index == 1)
            reloadTime = originalReloadTime;
        else if (index == 2)
            reloadTime = originalReloadTime * 2f;
    }

    void UpdateAmmo()
    {
        if (ammoText != null)
            ammoText.text = "Ammo: " + gunAmmo + "/" + maxAmmo;

        if (maxAmmoText != null)
            maxAmmoText.text = "Max Ammo: " + maxAmmo;
    }
}
