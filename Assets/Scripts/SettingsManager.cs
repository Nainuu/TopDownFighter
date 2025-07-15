using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    // public AudioMixer audioMixer;
    public Slider volumeSlider;

    void Start()
    {
        // Load volume from PlayerPrefs or default to 0.75
        float volume = PlayerPrefs.GetFloat("Volume", 0.75f);
        volumeSlider.value = volume;
        SetVolume(volume); // Apply it to the mixer
    }

    public void SetVolume(float volume)
    {
        // AudioMixer expects decibels — log10 scaling
        PlayerPrefs.SetFloat("Volume", volume);
        // audioMixer.SetFloat("Volume", Mathf.Log10(volume) * 20);
    }
}
