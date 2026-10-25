
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TMP_Text scoreText;
    public GameObject successText;
    public TMP_Dropdown collectibleDropdown;
    public int score = 0;
    public int requiredCollectibles = 5;

    void Start()
    {
        score = 0;
        scoreText.text = "Score: " + score;
        successText.SetActive(false);

        collectibleDropdown.onValueChanged.AddListener(SetRequiredCollectibles);
        SetRequiredCollectibles(collectibleDropdown.value);
    }

    public void SetRequiredCollectibles(int value)
    {
        requiredCollectibles = value + 1;
    }

    public void AddScore()
    {
        score++;
        scoreText.text = "Score: " + score;

        if (score >= requiredCollectibles)
        {
            successText.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void NextScene()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("training_camp");
    }
}
