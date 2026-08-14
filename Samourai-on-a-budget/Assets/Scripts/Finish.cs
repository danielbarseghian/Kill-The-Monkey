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
            // Get the PlayerController script so we can disable it
            PlayerMovement script = other.GetComponentInParent<PlayerMovement>();
            if (script != null)
                script.Disable_all();
            else
                Debug.Log("the Playermovement script was not found");

            levelHolder.currentLevel++;
            SceneManager.LoadScene(levelHolder.currentLevel);
        }
    }
}
