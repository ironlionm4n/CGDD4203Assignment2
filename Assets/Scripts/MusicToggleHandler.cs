using UnityEngine;
using UnityEngine.UI;

public class MusicToggleHandler : MonoBehaviour
{
    [SerializeField] private AudioSource _bgMusicSource;

    public void OnToggleSwitch(Toggle toggle)
    {
        _bgMusicSource.volume = !toggle.isOn ? 0 : 1;
    }
}
