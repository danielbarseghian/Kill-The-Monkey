using UnityEngine;
using UnityEngine.SceneManagement;

public class WinGlobal : MonoBehaviour
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

        SceneManager.LoadScene(script.currentLevel);
    }
}
