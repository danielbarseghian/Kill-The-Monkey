using UnityEngine;

public class LevelController : MonoBehaviour
{
    // This will hold the current level so the Restart button works :)
    public int currentLevel = 2;
    public int gravityMultiplier = 2;
    private static LevelController instance;

    private void Awake()
    {        
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Physics.gravity *= gravityMultiplier;
        
        instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
