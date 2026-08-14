using UnityEngine;

public class LevelController : MonoBehaviour
{
    // This will hold the current level so the Restart button works :)
    [HideInInspector] public int currentLevel = 0;
    public int gravityMultiplier = 2;
    private static LevelController instance;

    private void Awake()
    {
        Physics.gravity *= gravityMultiplier;
        
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
