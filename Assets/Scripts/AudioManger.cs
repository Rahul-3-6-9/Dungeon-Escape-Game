using UnityEngine.Audio;
using UnityEngine;
using System;
using Unity.VisualScripting;

public class AudioManger : MonoBehaviour
{
    public SoundManager[] sounds;
    void Awake()
    {
        foreach (SoundManager s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.outputAudioMixerGroup= FindObjectOfType<AudioMixerGroup>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    public void play(string name)
    {
          SoundManager s = Array.Find(sounds, sound => sound.name == name);
          s.source.Play();
    }

    public void stop(string name) 
    {
        SoundManager s = Array.Find(sounds, sound => sound.name == name);
        s.source.Stop();
    }

}
