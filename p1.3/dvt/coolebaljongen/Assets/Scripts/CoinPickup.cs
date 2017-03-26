using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    bool pickedup = false;
    private AudioSource a;

    void Start()
    {
        a = gameObject.AddComponent<AudioSource>();
        a.clip = Resources.Load<AudioClip>("pickupsound");
        a.loop = false;
        a.spatialBlend = 1.0f;
        a.playOnAwake = false;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (pickedup)
            return;

        if (other.CompareTag("Player"))
            GiveScore();
    }

    void GiveScore()
    {
        CurrentScore.Score += 1;
        CameraRotation.currentCoins--;
        pickedup = true;
        GetComponent<MeshRenderer>().enabled = false;
        GetWinCondition();
        PlaySound();
    }

    void PlaySound()
    {
        a.Play();
    }

    void GetWinCondition()
    {
        if(CameraRotation.currentCoins == 0)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("winscreen");
        }
    }

    public void Update()
    {
        transform.Rotate(0, 120 * Time.deltaTime, 0);
        if (!a.isPlaying && pickedup)
            Destroy(gameObject);
    }
}

public static class CurrentScore
{
    public static int Score { get; set; }
}
