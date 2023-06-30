using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }

    public List<Sound> sounds;
    private AudioSource audioSource;
    [SerializeField] private AudioSource backgroundMusic;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        else
            Destroy(gameObject);

        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
    }

    public void PlaySoundLoop(string name)
    {
        var sound = sounds.Find(s => s.name == name);

        if (sound == null)
        {
            Debug.LogWarning($"Sound with name {name} not found!");
            return;
        }

        backgroundMusic.loop = sound.loop;
        backgroundMusic.clip = sound.clip;
        backgroundMusic.volume = sound.volume;
        backgroundMusic.Play();
    }
    
    public void StopSoundLoop()
    {
        backgroundMusic.Stop();
    }

    public void PlaySound(string name)
    {
        var sound = sounds.Find(s => s.name == name);

        if (sound == null)
        {
            Debug.LogWarning($"Sound with name {name} not found!");
            return;
        }

        audioSource.PlayOneShot(sound.clip, sound.volume);
    }
}

[System.Serializable]
public class Sound
{
    public string name;
    public AudioClip clip;
    public bool loop;
    [Range(0, 1)] public float volume;
}