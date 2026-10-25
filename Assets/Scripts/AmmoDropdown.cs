
using UnityEngine;
using TMPro;

public class AmmoDropdown : MonoBehaviour
{
    public TMP_Dropdown ammoDropdown;
    public TMP_Text maxAmmoText;
    public ManageWeapons weapons;

    void Start()
    {
        ammoDropdown.onValueChanged.AddListener(UpdateAmmo);
        UpdateAmmo(ammoDropdown.value);
    }

    void UpdateAmmo(int value)
    {
        int[] multipliers = { 2, 5, 10 };

        weapons.maxAmmo = 10 * multipliers[value];
        weapons.RefillAmmo();

        maxAmmoText.text = "Max Ammo: " + weapons.maxAmmo;
    }
}
