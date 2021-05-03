using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    public Sound[] soundtracks;

    private Sound theme1;
    private Sound theme2;




    public static AudioManager instance;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (instance == null)
        {
            instance=this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }


        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }

        foreach (Sound s in soundtracks)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
       

        
    }

    void Start()
    {
        PlayTheme();
        
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name); // sound öylesine bir ad yer tutyor sadece

        if (s == null)
        {
            Debug.Log("Cant find the effect mate");
        }
        s.source.Play();
    }

    public void PlayTheme(String name)
    {
        theme1 = Array.Find(soundtracks, sound => sound.name == name);

        if (theme2.source.isPlaying)
        {
            theme2.source.Stop();
        }

        theme1.source.Play();


    }
    public void PlayTheme()
    {
        int length = soundtracks.Length-1;
        theme2 = soundtracks[UnityEngine.Random.Range(0, length)];       

        theme2.source.Play();

    }


    // Update is called once per frame
    void Update()
    {
        

        if (!theme2.source.isPlaying && (theme1==null ))
        {
            PlayTheme();
        }
    }
}
