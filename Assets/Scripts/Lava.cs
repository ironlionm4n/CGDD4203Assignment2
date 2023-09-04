using System;
using UnityEngine;

public class Lava : MonoBehaviour
{
    [SerializeField] private AudioSource bgMusicSource;
    [SerializeField] private AudioSource lavaSFXSource;
    
    public static event Action GameOver;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Rigidbody>().drag = 10f;
            bgMusicSource.Stop();
            lavaSFXSource.Play();
            GameOver?.Invoke();
        }
    }
}
