using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class Lamp : MonoBehaviour
{
	public Sprite activate;
	public Sprite deactivate;

	private SpriteRenderer _spriteRenderer;

	private void Awake()
	{
		_spriteRenderer = GetComponent<SpriteRenderer>();
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void DesactivateLamp()
	{
		_spriteRenderer.sprite = deactivate;
	}

	public void ActiveLamp()
	{
		_spriteRenderer.sprite = activate;
	}
}
