using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    [SerializeField] private AudioSource bgMusicSource;
    [SerializeField] private AudioSource lavaSFXSource;

    public static event Action Win;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            bgMusicSource.Stop();
            lavaSFXSource.Play();
            Win?.Invoke();
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
}
