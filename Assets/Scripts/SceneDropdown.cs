
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class SceneDropdown : MonoBehaviour
{
    public TMP_Dropdown sceneDropdown;

    public void ChangeScene(int index)
    {
        string sceneName = sceneDropdown.options[index].text;
        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneName);
    }
}
