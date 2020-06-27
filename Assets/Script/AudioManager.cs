using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    public float volume;

    public static AudioManager instance;

    /* 
      (AudioManagerReferenceGoeshere).StopPlaying("sound string name"); to stop the sound.
      FindObjectOfType<AudioManager>().Play("Name of sound"); to start sound.
     */
    void Awake()
    {
        foreach(Sound s in sounds)
        {
            if (instance == null)
                instance = this;
            else
            {
                DontDestroyOnLoad(gameObject);
                return;
            }

            s.source = gameObject.AddComponent<AudioSource>();
            volume = s.volume;
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }
    public void Play (string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        s.source.Play();
    }
}
