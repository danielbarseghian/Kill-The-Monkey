using UnityEngine;

public class Finish : MonoBehaviour
{
    public EnemyKilled script;
    void OnTriggerEnter(Collider other)
    {
        Debug.Log($"End, {script.enemyKilled}");
        if (script.enemyKilled >= script.killRequired)
        {
            Debug.Log("All enemies killed :)");
        }
    }
}
