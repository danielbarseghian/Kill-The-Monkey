using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    public EnemyKilled script;
    private LevelController levelHolder;

    void Start()
    {
        // Find the Level Controller script
        levelHolder = GameObject.FindGameObjectWithTag("LevelController").GetComponent<LevelController>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (script.enemyKilled >= script.killRequired)
        {
            levelHolder.currentLevel++;
            SceneManager.LoadScene(levelHolder.currentLevel);
        }
    }
}
