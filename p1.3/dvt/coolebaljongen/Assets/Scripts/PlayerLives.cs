using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLives : MonoBehaviour
{
    [SerializeField]
    int startingLives = 3;
    [SerializeField]
    Texture2D lifeTexture;
    int currentLives = 3;

    void Start()
    {
        currentLives = startingLives;
    }

    public void LoseLife()
    {
        if (--currentLives <= 0)
        {
            UnityEngine.SceneManagement.
                SceneManager.LoadScene("losescreen");
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Respawn"))
        {
            LoseLife();
            GetComponent<PlayerCheckpoint>().RespawnAtCheckpoint();
        }
    }

    void OnGUI()
    {
        if (lifeTexture)
            DrawLife();
    }

    void DrawLife()
    {
        for (int i = 0; i < currentLives; i++)
        {
            Rect rect = new Rect(32 + 64 * i, 128, 64, 64);
            GUI.DrawTexture(rect, lifeTexture);
        }
    }
}
