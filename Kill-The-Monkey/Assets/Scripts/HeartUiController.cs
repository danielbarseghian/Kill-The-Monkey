using UnityEngine.UI;
using UnityEngine;
using Unity.VisualScripting;
using System.Linq;

public class HeartUiController : MonoBehaviour
{
    public PlayerMovement player;
    public Image[] hearts = new Image[3];
    

    void Update()
    {
        for (int i = 0; i < hearts.Count(); i++)
        {
            if (player.hearts == i && hearts[i].enabled == true)
                {
                    hearts[i].enabled = false;
                }
        }
    }
}
