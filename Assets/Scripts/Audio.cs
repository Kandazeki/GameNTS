using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    public AudioClip sound;

    [Range(0f, 1f)]
    public float volume;
    
    [Range(0.1f, 2.5f)]
    public float pitch;

    private AudioSource source;

    public bool b = KillingCam2.audio;

    void Awake()
    {
        gameObject.AddComponent<AudioSource>();
        source = GetComponent<AudioSource>();

        volume = 0.5f;
        pitch = 1f;
    }

    void Start()
    {
        source.clip = sound;
        source.volume = volume;
        source.pitch = pitch;
    }

    // Update is called once per frame
    void Update()
    {
        if (KillingCam2.audio)
        {
            PlayAndPause();
            KillingCam2.audio = false;
        }
        source.volume = volume;
        source.pitch = pitch;
    }

    public void PlayAndPause()
    {
        if (!source.isPlaying)
        {
            source.Play();
        }
        else
        {
            source.Pause();
        }
    }
}
