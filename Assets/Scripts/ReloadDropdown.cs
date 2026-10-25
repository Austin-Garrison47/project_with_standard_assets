
using UnityEngine;
using TMPro;

public class ReloadDropdown : MonoBehaviour
{
    public TMP_Dropdown reloadDropdown;
    public ManageWeapons weapons;

    void Start()
    {
        reloadDropdown.onValueChanged.AddListener(UpdateReloadTime);
        UpdateReloadTime(reloadDropdown.value);
    }

    void UpdateReloadTime(int value)
    {
        if (value == 0)
        {
            weapons.reloadTime = 1f;
        }
        else if (value == 1)
        {
            weapons.reloadTime = 2f;
        }
        else
        {
            weapons.reloadTime = 4f;
        }
    }
}
