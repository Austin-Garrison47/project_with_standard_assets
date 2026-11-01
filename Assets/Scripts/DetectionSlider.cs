
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DetectionSlider : MonoBehaviour
{
    public Slider detectionSlider;
    public TMP_Text detectionValue;
    public ControlNPCFSM guard;

    void Start()
    {
        detectionSlider.onValueChanged.AddListener(UpdateDistance);
        UpdateDistance(detectionSlider.value);
    }

    void UpdateDistance(float value)
    {
        guard.detectionDistance = value;
        detectionValue.text = "Detection Distance: " + value;
    }
}
