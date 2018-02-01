using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxSound : MonoBehaviour {

    private AudioSource _audioSource;

    public void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        

    }
    public void DanslaBoite()
    {
        _audioSource.Play();
    }

    public void Disable()
    {

        _audioSource.Stop();
    }
}

