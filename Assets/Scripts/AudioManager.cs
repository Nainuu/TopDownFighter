using System;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    void Awake()
    {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.spatialBlend = 0f;
            s.source.loop = s.loop;
        }
    }
    void Start()
    {
        Debug.Log("AudioManager started");
        Play("Background");
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        else
        {
            Debug.Log("Playing sound: " + name);
            s.source.Play();
        }
    }
}
