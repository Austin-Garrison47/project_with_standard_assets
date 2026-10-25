
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ProjectileSlider : MonoBehaviour
{
    public Slider projectileSlider;
    public TMP_Text projectileValue;
    public LaunchProjectile[] launchers;

    void Start()
    {
        projectileSlider.onValueChanged.AddListener(UpdateForce);
        UpdateForce(projectileSlider.value);
    }

    void UpdateForce(float value)
    {
        float force = Mathf.Round(value / 100f) * 100f;
        projectileSlider.SetValueWithoutNotify(force);

        projectileValue.text = "Projectile Force: " + force;

        foreach (LaunchProjectile launcher in launchers)
        {
            launcher.projectileForce = force;
        }
    }
}
