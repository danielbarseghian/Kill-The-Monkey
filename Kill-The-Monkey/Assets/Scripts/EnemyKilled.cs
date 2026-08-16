using UnityEngine;
using TMPro;

public class EnemyKilled : MonoBehaviour
{
    [HideInInspector] public int enemyKilled = 0;
    public int killRequired = 5;
    public TextMeshProUGUI enemyKilledText;

    void Update()
    {
        enemyKilledText.SetText($"Objectif: {enemyKilled}/{killRequired}");
    }
}
