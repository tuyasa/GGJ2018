using UnityEngine;

public class PlasmaBowl : MonoBehaviour
{
    public Sprite inactiveSprite;
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    private AudioSource _audioSource;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _audioSource = GetComponent<AudioSource>();
    }

    public void Disable()
    {
        _animator.enabled = false;
        _spriteRenderer.sprite = inactiveSprite;
        _audioSource.Stop();
    }
}
