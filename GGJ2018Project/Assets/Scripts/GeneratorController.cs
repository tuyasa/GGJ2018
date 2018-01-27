using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorController : MonoBehaviour
{
	
	private SpriteRenderer _renderer;
	public Sprite Off;
	public Sprite On;
	private void Awake()
	{
		_renderer = GetComponentInChildren<SpriteRenderer>();
	}

	public void Switch()
	{
		Debug.Log("paf");
		_renderer.sprite = Off;
		Invoke("SwitchOn",1);
	}

	private void SwitchOn()
	{
		_renderer.sprite = On;
	}
}
