using System.Collections;
using System.Collections.Generic;
using Managers;
using UnityEngine;

public class GeneratorController : MonoBehaviour
{
	
	private SpriteRenderer _renderer;
	public Sprite Off;
	public Sprite On;
	public AudioClip switchSD;
	private void Awake()
	{
		_renderer = GetComponentInChildren<SpriteRenderer>();
	}

	public void Switch()
	{
		Debug.Log("paf");
		_renderer.sprite = Off;
		SoundManager.Instance.PlaySoundSFX(switchSD);
		Invoke("SwitchOn",1);
	}

	private void SwitchOn()
	{
		_renderer.sprite = On;
		
	}
}
