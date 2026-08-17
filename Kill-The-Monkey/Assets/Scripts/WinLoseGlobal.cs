using UnityEngine;
using UnityEngine.SceneManagement;

public class WinLoseGlobal : MonoBehaviour
{
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Restart()
    {
        LevelController script = GameObject.FindGameObjectWithTag("LevelController").GetComponent<LevelController>();

        Debug.Log($"index: {script.currentLevel}");
        SceneManager.LoadScene(script.currentLevel);
    }
}
