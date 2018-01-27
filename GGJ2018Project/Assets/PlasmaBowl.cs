using UnityEngine;

public class PlasmaBowl : MonoBehaviour
{
    public Sprite inactiveSprite;
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Disable()
    {
        _animator.enabled = false;
        _spriteRenderer.sprite = inactiveSprite;
    }
}
