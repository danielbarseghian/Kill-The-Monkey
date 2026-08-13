using UnityEngine;

public class LevelHolder : MonoBehaviour
{
    // This will hold the current level so the Restart button works :)
    [HideInInspector] public int currentLevel = 0;
    public int gravityMultiplier = 2;

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        Physics.gravity *= gravityMultiplier;
    }
}
