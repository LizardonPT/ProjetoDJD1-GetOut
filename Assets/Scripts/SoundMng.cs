using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundMng : MonoBehaviour
{
    static public SoundMng instance;

    private List<AudioSource> audioSources;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(this);
        audioSources = new List<AudioSource>();
    }
    public void PlaySound(AudioClip sound, float volume = 1)
    {
        AudioSource audioSource = NewSoundObject();
        audioSource.clip = sound;
        audioSource.volume = volume;
        audioSource.Play();
    }
    AudioSource NewSoundObject()
    {
        foreach(AudioSource audio in audioSources)
        {
            if (!audio.isPlaying)
            {
                return audio;
            }

        }
        GameObject gObject = new GameObject();
        gObject.transform.parent = transform;
        gObject.name = "SoundEffect";
        AudioSource audioSource = gObject.AddComponent<AudioSource>();
        audioSources.Add(audioSource);

        return audioSource;

    }
}
