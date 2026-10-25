
using UnityEngine;
using TMPro;

public class GameTimer : MonoBehaviour
{
    public TMP_Text timerText;
    private float time = 0f;

    void Update()
    {
        time += Time.deltaTime;
        timerText.text = "Time: " + Mathf.FloorToInt(time);
    }
}
