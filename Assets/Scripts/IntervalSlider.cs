
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class IntervalSlider : MonoBehaviour
{
    public Slider intervalSlider;
    public TMP_Text intervalValue;
    public LaunchProjectile[] launchers;

    void Start()
    {
        intervalSlider.onValueChanged.AddListener(UpdateInterval);
        UpdateInterval(intervalSlider.value);
    }

    void UpdateInterval(float value)
    {
        int interval = Mathf.RoundToInt(value);

        intervalValue.text = "Interval: " + interval + " seconds";

        foreach (LaunchProjectile launcher in launchers)
        {
            launcher.launchInterval = interval;
            launcher.CancelInvoke("Launch");
            launcher.InvokeRepeating("Launch", 2f, interval);
        }
    }
}
