using System.Collections;
using System.Collections.Generic;
using Managers;
using UnityEngine;

public class GeneratorController : MonoBehaviour
{
    private SpriteRenderer _renderer;
    public Sprite Off;
    public Sprite On;
    public AudioClip backgroundSD;
    public AudioClip OnSD;

    public AudioClip OffSD;

    private void Awake()
    {
        _renderer = GetComponentInChildren<SpriteRenderer>();
        SoundManager.Instance.PlayeBackgroundMusic(backgroundSD);
    }

    public void Switch()
    {
        Debug.Log("paf");
        _renderer.sprite = Off;
        SoundManager.Instance.PlaySoundSFX(OnSD);
        Invoke("SwitchOn", 1);
    }

    private void SwitchOn()
    {
        SoundManager.Instance.PlaySoundSFX(OffSD);
        _renderer.sprite = On;
    }
}