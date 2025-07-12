using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    // public AudioMixer audioMixer;
    // public Slider volumeSlider;

    void Start()
    {
        // Set initial slider value (e.g. from PlayerPrefs if needed)
        float volume = PlayerPrefs.GetFloat("Volume", 0.75f);
        // volumeSlider.value = volume;
        // SetVolume(volume);
    }

    public void SetVolume(float volume)
    {
        // audioMixer.SetFloat("Volume", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("Volume", volume);
    }
}
