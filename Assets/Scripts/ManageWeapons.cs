
using UnityEngine;
using TMPro;
using System.Collections;

public class ManageWeapons : MonoBehaviour
{
    public Camera playerCamera;
    public TMP_Text ammoText;
    public TMP_Text targetScoreText;
    public int gunAmmo = 10;
    public int maxAmmo = 10;
    public int targetScore = 0;
    public float shootingRange = 100f;
    public float reloadTime = 2f;

    private bool isReloading = false;

    void Start()
    {
        UpdateAmmo();
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
        gunAmmo--;
        UpdateAmmo();

        RaycastHit hit;

        if (Physics.Raycast(playerCamera.transform.position,
            playerCamera.transform.forward, out hit, shootingRange))
        {
            Debug.Log("Hit: " + hit.collider.name);

            ShootingTarget target = hit.collider.GetComponent<ShootingTarget>();

            if (target != null)
            {
                target.Hit();
                targetScore++;
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

    void UpdateAmmo()
    {
        ammoText.text = "Ammo: " + gunAmmo + "/" + maxAmmo;
    }
}
