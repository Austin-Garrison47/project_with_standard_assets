
using UnityEngine;
using TMPro;
using UnityStandardAssets.Characters.FirstPerson;

public class PauseGame : MonoBehaviour
{
    public TMP_Text buttonText;
    public GameObject preferences;
    public FirstPersonController fpsController;

    void Start()
    {
        Pause();
    }

    void Update()
    {
        if (fpsController == null)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");

            if (player != null)
            {
                fpsController = player.GetComponent<FirstPersonController>();

                if (fpsController != null && Time.timeScale == 0f)
                    fpsController.enabled = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    void LateUpdate()
    {
        if (Time.timeScale == 0f)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    public void TogglePause()
    {
        if (Time.timeScale == 0f)
            Resume();
        else
            Pause();
    }

    void Pause()
    {
        Time.timeScale = 0f;

        if (buttonText != null)
            buttonText.text = "Resume";

        if (preferences != null)
            preferences.SetActive(true);

        if (fpsController != null)
            fpsController.enabled = false;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    void Resume()
    {
        Time.timeScale = 1f;

        if (buttonText != null)
            buttonText.text = "Pause";

        if (preferences != null)
            preferences.SetActive(false);

        if (fpsController != null)
            fpsController.enabled = true;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
