using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Finish : MonoBehaviour
{
    public EnemyKilled script;
    private LevelController levelHolder;
    public TextMeshProUGUI enoughKills;

    [Header("UI Settings")]
    [Tooltip("How fast the text fades away. Higher = faster.")]
    public float fadeSpeed = 0.5f; 

    void Start()
    {
        levelHolder = GameObject.FindGameObjectWithTag("LevelController").GetComponent<LevelController>();

        SetTextAlpha(0f);
    }

    void Update()
    {
        if (enoughKills.color.a > 0)
        {
            Color currentColor = enoughKills.color;
            currentColor.a -= fadeSpeed * Time.deltaTime;
            enoughKills.color = currentColor;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (script.enemyKilled >= script.killRequired)
            {
                levelHolder.currentLevel++;
                SceneManager.LoadScene(levelHolder.currentLevel);
            }
            else
            {
                enoughKills.SetText($"You need {script.killRequired - script.enemyKilled} more kills");
                SetTextAlpha(1f);
            }
        }
    }

    private void SetTextAlpha(float targetAlpha)
    {
        // make a new color
        Color newColor = enoughKills.color;

        // Aplly the wanted alpha (transparancy)
        newColor.a = targetAlpha;

        // and set it
        enoughKills.color = newColor;
    }
}