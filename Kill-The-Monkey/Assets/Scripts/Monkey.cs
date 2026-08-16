using UnityEngine;
using UnityEngine.SceneManagement;

public class Monkey : MonoBehaviour
{
    public int health = 10000;

    void Update()
    {
        if (health <= 0)
        {
            SceneManager.LoadScene(4);
            Destroy(this.gameObject);
        }
    }
}
