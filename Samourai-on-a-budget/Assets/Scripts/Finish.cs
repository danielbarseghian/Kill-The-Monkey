using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    public EnemyKilled script;
    void OnTriggerEnter(Collider other)
    {
        if (script.enemyKilled >= script.killRequired)
        {
            SceneManager.LoadScene(1);
        }
    }
}
