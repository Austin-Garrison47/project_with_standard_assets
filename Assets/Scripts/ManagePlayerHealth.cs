
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ManagePlayerHealth : MonoBehaviour
{
    public int health = 100;
    public int nbLives = 3;

    public TMP_Text healthInfo;
    public TMP_Text livesInfo;

    private static int savedLives = 3;
    private bool gameOver = false;

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
    static void ResetLives()
    {
        savedLives = 3;
    }

    void Start()
    {
        nbLives = savedLives;
        health = 100;
        UpdateHealthDisplay();
    }

    void Update()
    {
        UpdateHealthDisplay();
    }

    public void decreaseHealth(int amount)
    {
        if (gameOver)
            return;

        health -= amount;

        if (health <= 0)
            restartLevel();
    }

    public void increaseHealth(int amount)
    {
        if (gameOver)
            return;

        health += amount;
        health = Mathf.Clamp(health, 0, 100);
        UpdateHealthDisplay();
    }

    public void restartLevel()
    {
        if (gameOver)
            return;

        nbLives--;
        savedLives = nbLives;
        health = 100;

        if (nbLives > 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else
        {
            gameOver = true;
            nbLives = 0;
            SceneManager.LoadScene("loseScene");
        }
    }

    void UpdateHealthDisplay()
    {
        if (healthInfo != null)
            healthInfo.text = "Health: " + health;

        if (livesInfo != null)
            livesInfo.text = "Lives: " + nbLives;
    }
}
