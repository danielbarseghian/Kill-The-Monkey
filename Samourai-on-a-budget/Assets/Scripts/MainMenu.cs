using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public RectTransform button;
    public RectTransform canvas;
    public float seconds = 2f;

    void Start()
    {
        // Invokle it every secondes
        InvokeRepeating(nameof(Teleport), seconds, seconds);
    }

    void Teleport()
    {
        // Get a random position on the canva on the x axis
        float x = Random.Range(
            -canvas.rect.width / 2 + button.rect.width / 2,
             canvas.rect.width / 2 - button.rect.width / 2
        );

        // Get a random position on the canva on the y axis
        float y = Random.Range(
            -canvas.rect.height / 2 + button.rect.height / 2,
             canvas.rect.height / 2 - button.rect.height / 2
        );

        // Set the position
        button.anchoredPosition = new Vector2(x, y);
    }

    public void Play()
    {
        SceneManager.LoadScene(0);
    }

    public void Quit()
    {
        Application.Quit();
    }
}