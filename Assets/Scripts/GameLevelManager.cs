
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameLevelManager : MonoBehaviour
{
    public TMP_Text collectibleText;
    public int collectiblesNeeded = 5;

    private int collectiblesCollected = 0;

    void Start()
    {
        collectiblesCollected = 0;
        UpdateCollectibleText();
    }

    public void CollectObject()
    {
        collectiblesCollected++;
        UpdateCollectibleText();

        if (collectiblesCollected >= collectiblesNeeded)
        {
            WinLevel();
        }
    }

    void UpdateCollectibleText()
    {
        collectibleText.text = "Collected: " +
            collectiblesCollected + "/" + collectiblesNeeded;
    }

    void WinLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("winScene");
    }
}
