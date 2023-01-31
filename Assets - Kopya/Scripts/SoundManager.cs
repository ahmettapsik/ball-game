using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    public AudioSource musicS;
    public AudioSource audioS;

    public List<AudioSource> audioSources;

    public AudioClip goalSound;
    public AudioClip effect;

    void Start()
    {
        if (instance == null)
            instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaySound(AudioClip auido)
    {
        audioS.clip = auido;
        audioS.Play();
    }

    public void ChangeAudioVolume(Slider slider)
    {
        foreach (AudioSource audioSource in audioSources)
        {
            audioSource.volume = slider.value;
        }
        audioSources[0].volume *= .85f;
    }
}
